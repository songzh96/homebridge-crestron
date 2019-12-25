# 如果你需要定制开发，请发邮件给我，开发这个插件也是需要很多时间的，请理解。
### V2.0

**1. 本项目是基于[homebridge-creskit](https://github.com/marcusadolfsson/homebridge-creskit)进行二次开发的。**

**2. 修改了event事件中的setValue->updateValue。避免重复发值给快思聪。**

**3. 删除了部分Get事件中的event提交请求（部分有所保留，要更新其状态，因为有的配件获取到的值传不到homebridge）**

**4. 删除set事件中的匹配机制，因为我发现根本没必要了**

**5.在原版的基础上增加了多种配件（调光调色灯，空调，风扇，空净以及各类传感器等）**

### V2.1

**1.修复用Siri对调光灯说“把灯打开”没反应**

**2.增加地暖配件（只可控制温度和开关）**

### V2.2
**1.修复窗帘更新状态的BUG**

**2.修复空气净化器更新状态的BUG**

**3.代码清理**

**4.增加了电视和窗户**

### V2.2.1
**1.修复一些BUG**


![HomeBridge.png](https://upload-images.jianshu.io/upload_images/3246153-34905aac5cb382fe.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)
![Crestron](https://upload-images.jianshu.io/upload_images/3246153-847e7112c89bc585.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

# 使用教程
#### 硬件准备
1. 树莓派（建议购买套件，可让店家帮忙安装系统）
2. 快思聪中控系统

#### 软件准备
1. 为树莓派安装系统，建议安装官方原生系统（已安装的请忽略）。。。。请自行百度
2. [搭建homebridge环境教程](https://github.com/nfarina/homebridge/wiki/Running-HomeBridge-on-a-Raspberry-Pi),    **本人亲测，可以使用**
3. 打开终端输入    `sudo npm install -g homebridge-creskit2`
4. 配置`config.json` 
  - ` sudo nano /home/pi/.homebridge/config.json`
复制以下内容，然后ctrl+o 回车 ctrl+x

```
{
    "bridge": {
        "name": "Creskit",
        "username": "CC:22:3D:E3:CE:32",
        "port": 51826,
        "pin": "031-45-154"
    },

    "platforms": [
    {
      "platform": "CresKit",
      "name": "CresKit",
      "host": "192.168.5.22", // IP Address of Crestron System
      "port": "50001", // Match Port specified in Modue

      "accessories":[
        {
          "id":1,
          "type":"Lightbulb",
          "name":"Marcus Sidelight"
        },
        {
          "id":2,
          "type":"Lightbulb",
          "name":"Casey Sidelight"
        },
        {
          "id":3,
          "type":"Lightbulb",
          "name":"Bathroom"
        },
        {
          "id":1,
          "type":"Switch",
          "name":"Good Night Scene" 
        }

      ]
    }
  ]
}
```

- 在终端中输入`homebridge`
- 根据错误解决问题（一般是以下两个问题）
   1. error conected 查看config.json中的快思聪主机IP和Port对不对，快思聪程序要先上传
   
   2. json文件格式有误，[json文件格式验证](https://jsonlint.com/)
- 成功后会出现一个二维码，打开IOS设备，选择家庭-添加配件-扫描二维码-确认添加
- 打开toolbox进行测试
- 成功后，可自行查阅源码，进行自定义修改以及研究原理

#### 其他信息

**QQ Group:** 107927710，本群有很多大神，主要是小米对接HomeKit

如果有什么问题可以直接issue提问












