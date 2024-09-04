# SnowModManager
![](https://img.shields.io/github/downloads/kirileec/SnowModManager/total)
![](https://img.shields.io/github/license/kirileec/SnowModManager)

[README](README.md)

## 功能列表

1. 记录上次选择的游戏目录
2. 拖拽pak文件安装mod
3. 按照角色名(分类)管理mod
4. 管理员权限运行支持自动获取游戏目录(拖拽会失效)
5. 随时启用或禁用一个mod, 需重进游戏
6. 监听mod目录, 自动刷新

## TODO

- [ ] mod备注功能
- [ ] 多语言(也许吧)


## 使用注意

- 依赖 .NET8 运行环境
- 如果以右键管理员权限运行, 可从注册表自动读取游戏目录, 
但是由于Windows的资源管理器默认是普通身份运行, 因此拖拽功能将失效, 可以首次以管理员运行一次, 后续直接双击运行即可
