# UnityDemo
工作中收集的一些Unity的一些小例子
****
### Author : Xieliujian
### E-mail : 377624289@qq.com
****
## Demo例子
* [BoomBeachOcean](#Demo1)
* [ThirdPersonCam](#Demo2)
* [AnimClipExtract](#Demo3)
* [UIModelShow](#Demo4)
* [Localization](#Demo5)
* [QQWechatAuthLoign](#Demo6)
****

<h2 id="Demo1">BoomBeachOcean的Demo展示海岛奇兵匹配地图海洋的效果</h2>

* a, 效果图如下:
![效果图](https://github.com/xieliujian/UnityDemo/blob/master/Snapshot/BoomBeachOcean/Ocean.png)
****

<h2 id="Demo2">ThirdPersonCam的Demo展示第三人称摄像机效果</h2>

* a, 效果图如下:
![效果图](https://github.com/xieliujian/UnityDemo/blob/master/Snapshot/ThirdPersonCam/Screenshot_2017-05-24-22-54-15_com.FengShen.Third.png)
![效果图](https://github.com/xieliujian/UnityDemo/blob/master/Snapshot/ThirdPersonCam/Screenshot_2017-05-24-22-54-23_com.FengShen.Third.png)
![效果图](https://github.com/xieliujian/UnityDemo/blob/master/Snapshot/ThirdPersonCam/Screenshot_2017-05-24-22-54-43_com.FengShen.Third.png)
****

<h2 id="Demo3">AnimClipExtract的Demo展示提取AnimationClip的方法</h2>

* a, 效果图如下:
![效果图](https://github.com/xieliujian/UnityDemo/blob/master/Snapshot/AnimClipExtract/AnimClipExtract.png)

* b, 功能说明:  
这个工具的作用是把美术导出的动画fbx提取出动画，在使用Animator的时候只要使用这些提取的动画clip，打包的时候也只会打包这些提取的动画clip，减少包体大小
****

<h2 id="Demo4">UIModelShow的Demo展示王者荣耀ui中显示3d模型的方法</h2>

* a, 效果图如下:
![效果图](https://github.com/xieliujian/UnityDemo/blob/master/Snapshot/UIModelShow/UIModelShow.png)

* b, 功能说明:  
这个Demo展示王者荣耀ui中显示3d模型的方法
![效果图](https://github.com/xieliujian/UnityDemo/blob/master/Snapshot/UIModelShow/MainCam.png)
![效果图](https://github.com/xieliujian/UnityDemo/blob/master/Snapshot/UIModelShow/UIModelCam.png)
![效果图](https://github.com/xieliujian/UnityDemo/blob/master/Snapshot/UIModelShow/UICam.png)
如上面3张截图所示，技术点在Camera的Depth分层和Culling Mask的Layer剔除, MainCam先渲染，渲染的是场景内的物体（但不包括ui和uimodel层）, 然后渲染UIModelCam, 只渲染uimodelcam层的物体，最后渲染ui，这样就是实现王者荣耀ui的模型显示的方法
****

<h2 id="Demo5">Localization的Demo展示ngui中多语言的使用</h2>

* a, 效果图如下:
![效果图](https://github.com/xieliujian/UnityDemo/blob/master/Snapshot/Localization/English.png)
![效果图](https://github.com/xieliujian/UnityDemo/blob/master/Snapshot/Localization/Français.png)
![效果图](https://github.com/xieliujian/UnityDemo/blob/master/Snapshot/Localization/Chinese.png)

****

<h2 id="Demo6">QQWechatAuthLogin的Demo展示使用ShareSDK进行QQ和Wechat登录</h2>

* a, 效果图如下:
![效果图](https://github.com/xieliujian/UnityDemo/blob/master/Snapshot/QQWechatAuthLogin/QQ20171021-153400%402x.png)

* b, QQ Wechat在Android集成注意

主要的实现代码里已经提供，注意的如下图所示

![效果图](https://github.com/xieliujian/UnityDemo/blob/master/Snapshot/QQWechatAuthLogin/QQ20171021-201447%402x.png)

需要提供一个和包名一样的jar包，不然微信登录不能成功

* c, QQ WeChat在iOS集成注意

![效果图](https://github.com/xieliujian/UnityDemo/blob/master/Snapshot/QQWechatAuthLogin/QQ20171021-201531%402x.png)

如图所示，QQ需要填写3个 qq, qzone qqseries(关键是这个，ios上可能就读这个)

wechat需要填写2个 wechat wechatseries(关键是这个, ios上可能就读这个)

![效果图](https://github.com/xieliujian/UnityDemo/blob/master/Snapshot/QQWechatAuthLogin/QQ20171021-201912%402x.png)

导出包的后处理时候，需要写入plist字段，需要填写正确的 url schemes