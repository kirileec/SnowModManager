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
7. 备注mod

## TODO

- [x] mod备注功能
- [ ] 多语言(也许吧)

## 更新

- 增加2.7兼容的相关选项, 新版本mod文件需要以_100_P.pak为后缀, 否则进游戏会提示 `Game resources broken`
	- 增加批量改名功能
	- 拖拽安装mod会自动将原_P.pak 改名为 _100_P.pak 再放到mod目录
- 点击禁用后光标不要跳到第一个
- 增加拖拽压缩包支持, 可直接拖拽压缩包, 无需解压(自动解压pak文件出来进行处理)


## 使用注意

- 依赖 .NET8 运行环境
- 如果以右键管理员权限运行, 可从注册表自动读取游戏目录, 
但是由于Windows的资源管理器默认是普通身份运行, 因此拖拽功能将失效, 可以首次以管理员运行一次, 后续直接双击运行即可
