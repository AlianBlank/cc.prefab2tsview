# cc.prefab2tsview



# 将Cocos Creator 预制体中的子节点生成View代码，直接使用。而不需要去做大量的getChildByName 操作。提高工作效率

## Use

import Utility from './Utility';

```bash 
    @echo off
    start CC.exe -[src] -[out]
```

-src => cc.prefab src Path, recursive / 预制体的存储目录,递归子目录

-out => *.ts save Root Path / `ts` 文件存储目录

