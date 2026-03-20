# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## 项目概述

基于小说《遮天》九秘的 Terraria tModLoader 模组。包含9个基础护符、合成护符、高级护符和终极护符。

## 构建命令

```bash
# 构建模组
dotnet build

# 注意：构建前必须关闭 tModLoader，否则会报 TML003 错误
```

构建输出：`bin/Debug/net8.0/TheNineSecrets.dll`

## 核心架构

### 护符继承体系

所有护符继承自 `BaseSecretAccessory` 基类：

```
BaseSecretAccessory (abstract)
├── Tier 1: 9个基础护符 (Items/Accessories/BaseSecrets/)
├── Tier 2: 5个合成护符 (Items/Accessories/Combined/)
├── Tier 3: 3个高级护符 (Items/Accessories/Tier3/)
└── Tier 4: 1个终极护符 (Items/Accessories/Ultimate/)
```

基类关键特性：
- `Tier` 属性决定稀有度和价值
- `CanEquipAccessory()` 实现互斥装备系统（同时只能装备一个护符）
- `ApplySecretEffects()` 虚方法由子类实现具体效果

### 玩家状态管理

`Players/SecretPlayer.cs` 集中管理所有护符效果状态：
- 使用布尔标志跟踪已装备护符（如 `hasZhenSecret`, `hasXingSecret`）
- 处理子弹时间、濒死保护、闪避等主动能力
- 在 `ResetEffects()` 中重置状态

### Boss掉落配置

`NPCs/GlobalSecretDrop.cs` 使用 `GlobalNPC` 处理Boss掉落：
- 使用 `ItemDropRule.Common()` 定义掉落规则
- 掉落率为 `1` 表示100%必掉

### 本地化

本地化文件位于 `Localization/`：
- `en-US_Mods.TheNineSecrets.hjson` - 英文
- `zh-Hans_Mods.TheNineSecrets.hjson` - 简体中文

## 添加新护符

1. 在对应目录创建继承 `BaseSecretAccessory` 的类
2. 重写 `SecretName`, `SecretDescription`, `Tier`, `ApplySecretEffects()`
3. 如需配方，重写 `AddRecipes()`
4. 在 `SecretPlayer.cs` 添加对应状态标志
5. 更新本地化文件

## 文件结构要点

```
Items/
├── Accessories/
│   ├── BaseSecrets/      # Tier 1 基础护符
│   ├── Combined/         # Tier 2 合成护符
│   ├── Tier3/            # Tier 3 高级护符
│   └── Ultimate/         # Tier 4 终极护符
└── Crafting/             # 合成材料
Players/                  # ModPlayer 状态管理
NPCs/                     # GlobalNPC Boss掉落
Projectiles/              # ModProjectile 弹幕
Tiles/                    # ModTile 物块
Buffs/                    # ModBuff 增益/减益
Systems/                  # ModSystem 系统集成
```

## 注意事项

- 修改 `icon.png` 必须保持 80x80 像素
- 护符数值应保持平衡，参考现有数值量级
- 合成护符需要在 `SecretForgeTile` 处制作