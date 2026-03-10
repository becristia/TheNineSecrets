# CLAUDE.md

本文件为 Claude Code (claude.ai/code) 在此代码库中工作时提供指导。

## 项目概述

这是一个名为"The Nine Secrets"的 Terraria tModLoader 模组，使用标准的 tModLoader 模组框架。

## 构建与开发命令

### 构建模组
- 通过 IDE（Visual Studio/Rider）使用 .csproj 文件进行构建
- 项目从父级 tModLoader 安装目录导入 `..\tModLoader.targets`
- 构建输出位于 `bin/Debug/` 目录（调试版本）

### 运行/测试
`Properties/launchSettings.json` 中配置了两个启动配置文件：
- **Terraria**: 启动 tModLoader 客户端进行测试
- **TerrariaServer**: 启动 tModLoader 服务器进行测试

## 架构

### 模组入口点
`TheNineSecrets.cs` 包含主类 `TheNineSecrets`，继承自 `Terraria.ModLoader.Mod`。这是模组功能的中央枢纽。

### 内容组织
tModLoader 使用基于约定 的内容发现机制。在以下子目录中添加内容：
- `Items/` - ModItem 类，用于自定义物品
- `NPCs/` - ModNPC 类，用于自定义 NPC
- `Projectiles/` - ModProjectile 类，用于自定义弹幕
- `Tiles/` - ModTile 类，用于自定义物块
- `Buffs/` - ModBuff 类，用于自定义增益/减益
- `Systems/` - ModSystem 类，用于世界/玩家钩子
- `Players/` - ModPlayer 类，用于玩家修改

### 本地化
本地化使用 HJSON 格式，文件位于 `Localization/en-US_Mods.TheNineSecrets.hjson`。

### 构建元数据
`build.txt` 包含模组元数据：
- displayName: The Nine Secrets
- author: man
- version: 0.1

## 参考
- [tModLoader 基础模组制作指南](https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide)