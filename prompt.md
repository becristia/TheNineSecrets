# 遮天九秘 · 泰拉瑞亚饰品系统设计

##  设计理念

九秘作为九种无上秘术，采用**互斥装备系统**，玩家只能同时装备一枚"印"，但可通过合成解锁更强大的**组合秘术**，包含9个基础饰品、多个合成饰品、互斥装备系统、自定义合成台。由于系统变化，boss生命值和攻击力均有所提升，生命值提升50%，攻击力提高30%。

---

## 基础九印（Tier 1）

| 秘术 | 饰品名称 | 获取阶段 | 获取方式 | 效果 |
|------|---------|---------|---------|------|
| **斗** | 斗字印 | 困难模式前 | 地牢金箱/地下 shrine | +15% 近战伤害，攻击时有5%概率触发额外打击 |
| **者** | 者字印 | 困难模式前 | 地下丛林宝箱 | +2HP/s 生命回复，受伤后额外+5HP/s持续5秒 |
| **临** | 临字印 | 困难模式前 | 冰原宝箱/雪原地牢 | +20% 防御，受到致命伤害时保留1HP（60秒冷却） |
| **兵** | 兵字印 | 困难模式 | 击败任意机械Boss后掉落 | +10% 所有伤害，武器击退+50% |
| **皆** | 皆字印 | 困难模式 | 地下神圣地箱 | +10% 暴击率，+15% 掉落率，+5% 稀有物品概率 |
| **阵** | 阵字印 | 困难模式 | 击败世纪之花后掉落 | 召唤2个符文环绕自身，接触敌人造成50 DPS |
| **列** | 列字印 | 困难模式 | 地下丛林神庙宝箱 | +25% 移动速度，+15% 加速度，可无限疾跑 |
| **行** | 行字印 | 困难模式后 | 击败石巨人后掉落 | 闪避率+20%，闪避后3秒内移动速度+100% |
| **前** | 前字印 | 月球领主前 | 击败火星暴乱/日食掉落 | 子弹时间5秒（受伤触发，120秒冷却），+10% 暴击伤害 |

---

## 合成系统（核心机制）

### 合成台：**秘术熔炉**
```
合成材料：远古秘术台 × 1 + 秘银砧 × 1
掉落：击败世纪之花后概率掉落配方
```

### 合成规则
- **3印合成** → 解锁**双秘术**（Tier 2）
- **6印合成** → 解锁**三秘术**（Tier 3）
- **9印合成** → 解锁**九秘合一**（Tier 4 - 终极）

---

## Tier 2 · 双秘术组合

| 组合 | 饰品名称 | 合成配方 | 效果 |
|------|---------|---------|------|
| **斗+兵** | 斗兵秘印 | 斗字印+兵字印+秘术核心 | +30% 近战伤害，武器大小+20%，攻击附带剑气 |
| **者+临** | 者临秘印 | 者字印+临字印+秘术核心 | +5HP/s 回复，+30% 防御，受伤后无敌2秒（90秒冷却） |
| **皆+前** | 皆前秘印 | 皆字印+前字印+秘术核心 | +20% 暴击率，+25% 暴击伤害，子弹时间延长至8秒 |
| **行+列** | 行列秘印 | 行字印+列字印+秘术核心 | +40% 移动速度，闪避率+30%，可空中二段冲刺 |
| **阵+皆** | 阵皆秘印 | 阵字印+皆字印+秘术核心 | 召唤4个符文，+20% 掉落率，符文伤害随幸运提升 |

---

## Tier 3 · 三秘术组合

| 组合 | 饰品名称 | 合成配方 | 效果 |
|------|---------|---------|------|
| **斗+兵+者** | 战圣秘印 | 斗兵秘印+者字印+高阶核心 | +40% 伤害，+3HP/s 回复，击杀敌人恢复2% 生命 |
| **行+列+前** | 瞬影秘印 | 行列秘印+前字印+高阶核心 | +50% 移动速度，闪避后触发子弹时间3秒，可穿墙5秒 |
| **临+阵+皆** | 守护秘印 | 者临秘印+阵字印+高阶核心 | +40% 防御，6个符文环绕，受到致命伤害时符文抵消（3符文/次） |

---

## Tier 4 · 九秘合一（终极）

### **九秘源印**
```
合成配方：
- 所有9个基础印（或3个三秘术印）
- 月球领主精华 × 10
- 秘术核心（终极）× 1
- 合成台：远古秘术熔炉
```

### 效果：
| 属性 | 数值 |
|------|------|
| 所有伤害 | +50% |
| 防御 | +40 |
| 生命回复 | +8HP/s |
| 暴击率 | +25% |
| 暴击伤害 | +40% |
| 移动速度 | +60% |
| 闪避率 | +35% |
| 掉落率 | +30% |
| 特殊能力 | 8个符文环绕，子弹时间（10秒/180秒冷却），濒死无敌3秒 |

---
### 参考文件结构
NineSecrets/
├── NineSecrets.csproj
├── Properties/launchSettings.json
├── description.json
├── NineSecrets.cs (主模组类)
├── Items/
│ ├── Accessories/
│ │ ├── BaseSecrets/
│ │ │ ├── DouSecret.cs
│ │ │ ├── ZheSecret.cs
│ │ │ ├── LinSecret.cs
│ │ │ ├── BingSecret.cs
│ │ │ ├── JieSecret.cs
│ │ │ ├── ZhenSecret.cs
│ │ │ ├── LieSecret.cs
│ │ │ ├── XingSecret.cs
│ │ │ └── QianSecret.cs
│ │ ├── Combined/
│ │ │ ├── DouBingSecret.cs
│ │ │ ├── ZheLinSecret.cs
│ │ │ ├── JieQianSecret.cs
│ │ │ ├── XingLieSecret.cs
│ │ │ └── ZhenJieSecret.cs
│ │ └── Ultimate/
│ │ └── NineSecretsUltimate.cs
│ ├── Crafting/
│ │ ├── SecretForge.cs (秘术熔炉)
│ │ └── SecretCore.cs (秘术核心)
│ └── Global/
│ └── NineSecretsGlobalItem.cs
├── Buffs/
│ ├── SecretBuff.cs (基础Buff)
│ └── NineSecretsMutualExclusiveBuff.cs (互斥Buff)
├── NPCs/
│ └── NPCDropLoader.cs
├── Recipes/
│ └── RecipeLoader.cs
├── Content/
│ ├── Images/
│ │ └── Items/ (饰品图标)
│ └── Sounds/
└── Localization/
└── zh-Hans_Mods.NineSecrets.hjson


## 获取进度树

```
困难模式前
├── 斗字印（地牢）
├── 者字印（丛林）
└── 临字印（雪原）
        ↓
困难模式（机械Boss后）
├── 兵字印（机械Boss掉落）
├── 皆字印（神圣地）
└── 阵字印（世纪之花）
        ↓
困难模式后（石巨人后）
├── 列字印（神庙）
├── 行字印（石巨人掉落）
└── 前字印（火星/日食）
        ↓
月球领主前
└── 合成双秘术/三秘术
        ↓
月球领主后
└── 九秘源印（终极）
```

---
## 代码规范

### 使用 tModLoader 1.4+ 标准
```csharp
// 饰品基类示例
public abstract class BaseNineSecretAccessory : ModItem
{
    public override void SetDefaults()
    {
        Item.accessory = true;
        Item.maxStack = 1;
    }
    
    public override void UpdateAccessory(Player player, bool hideVisual)
    {
        // 检查互斥
        if (!CanEquip(player)) return;
        
        // 应用效果
        ApplyEffects(player);
    }
    
    protected abstract bool CanEquip(Player player);
    protected abstract void ApplyEffects(Player player);
}
```


## 互斥系统实现（代码思路）

### Buff 系统：
```csharp
// 九秘互斥Buff
public class NineSecretsBuff : ModBuff
{
    public override void SetStaticDefaults()
    {
        // 所有九秘Buff互相排斥
        Main.buffNoTime[Type] = true;
    }
    
    public override void Update(Player player, int buffIndex)
    {
        // 检测是否装备其他九秘饰品
        // 如果有，移除当前Buff
    }
}
```

### 饰品检测：
```csharp
// 在饰品Update中
public override void UpdateEquip(Player player)
{
    // 检查其他九秘饰品
    foreach(var item in player.armor)
    {
        if(item.IsNineSecrets() && item.type != this.Type)
        {
            // 提示玩家只能装备一个
            return;
        }
    }
    
    // 应用效果
    ApplySecretEffect(player);
}
```

---

## 视觉设计建议

| 饰品 | 外观 | 特效 |
|------|------|------|
| 斗字印 | 红色符文玉佩 | 攻击时红色光芒闪烁 |
| 者字印 | 绿色符文玉佩 | 周围有绿色治疗粒子 |
| 临字印 | 金色符文玉佩 | 受到攻击时金色护盾 |
| 兵字印 | 银色符文玉佩 | 武器周围有银色光晕 |
| 皆字印 | 紫色符文玉佩 | 周围有紫色幸运星 |
| 阵字印 | 蓝色符文玉佩 | 符文环绕旋转 |
| 列字印 | 青色符文玉佩 | 移动时青色拖尾 |
| 行字印 | 白色符文玉佩 | 闪避时白色残影 |
| 前字印 | 黑色符文玉佩 | 子弹时间时屏幕变暗 |
| 九秘源印 | 九色符文玉佩 | 9色符文环绕，光芒流转 |

---

## 平衡性建议

1. **前期**（困难模式前）：3个基础印提供生存/输出选择
2. **中期**（困难模式）：6个印解锁，双秘术合成增加build多样性
3. **后期**（月球领主）：三秘术/九秘合一提供终极追求

4. **互斥机制**：防止玩家叠加所有效果，鼓励根据Boss/场景选择
5. **合成成本**：需要投入资源，增加成就感

---

## 物品ID命名建议

```
ItemID:
- NineSecrets_Dou      // 斗
- NineSecrets_Zhe      // 者
- NineSecrets_Lin      // 临
- NineSecrets_Bing     // 兵
- NineSecrets_Jie      // 皆
- NineSecrets_Zhen     // 阵
- NineSecrets_Lie      // 列
- NineSecrets_Xing     // 行
- NineSecrets_Qian     // 前

- NineSecrets_Combined_XX  // 组合印
- NineSecrets_Ultimate     // 九秘源印
```

---

## 生成任务（参考）

请按以下顺序生成代码：

1. **第一阶段**：主模组类 + 基础结构
2. **第二阶段**：9个基础饰品 (Dou, Zhe, Lin, Bing, Jie, Zhen, Lie, Xing, Qian)
3. **第三阶段**：互斥系统 + Buff系统
4. **第四阶段**：合成台 + 合成配方
5. **第五阶段**：合成饰品 (双秘术/三秘术/终极)
6. **第六阶段**：NPC掉落配置 + 本地化文件
7. **第七阶段**：视觉效果 (粒子/图标占位符)