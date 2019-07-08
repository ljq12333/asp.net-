<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alllogin.aspx.cs" Inherits="选题系统.login" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head runat="server">
    <title>Document</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="./css/login.css" rel="stylesheet"/>
<script type="text/javascript" src="./js/jquery-3.3.1.min.js"></script>
</head>
<body runat="server">
    <div class="container" runat="server">
        <div class="center_header">
            <div class="header"></div>
            <div class="wenzi">
            <div class="logo"><img src="./images/logo-1.png"></div>
            <div class="font">
                <font face="黑体" size="7" color="#000000">
                    <b>学生毕业设计选题系统</b>
                </font>
            </div>
            </div>
        </div>
        <div class="center_middle">
            <div class="middle_left">
                <div class="guize">
                        <p><b>系统使用说明</b></p>
                        <p>I、学生登录帐号为学号，原始密码为学号。</p>

                        <p>II、登录成功后，每位学生可以选三个题目，有需要的学生，添加一个自选题。</p>
                        
                        <p>III、学生选题后，由老师决定选择学生。</p>
                        
                        <p>IV、学生一旦选题后，不要更改，除非开始选择的三个题目都被别人选定。</p>
                        
                        <p>V、若教师的账号没有开启，则不能提交新的题目，如有需要，请联系管理员。</p>
                        
                        <p>VI、为了保障您的信息的安全，每次操作完该系统后，请选择安全退出。</p>
                </div>            
            </div>
            <div class="middle_right">
                <div class="login">
                <form action="index.php">
                    <div class="id">
                        <label>账号：</label><input type="text" maxlength="20" placeholder="请输入你的学号" runat="server" id="id">
                    </div>
                    <div class="pwd">
                        <label>密码：</label><input type="password" maxlength="20" placeholder="请输入正确的密码" runat="server" id="pwd"> 
                    </div>
                    <div class="radio">
                        <input type="radio" name="he" value="教师" />教师
                        <input type="radio" name="he" value="学生" />学生
                    </div>
                   
                    <div class="button">
                        <input type="button" value="登录" runat="server" id="login1">
                        <input type="reset" value="重置">
                    </div>
                </form>
                </div>
            </div>
        </div>
        <div class="center_bottom">
           <p>© 2009-2019 东北师范大学 计算机科学技术学院网络专业 dx.gdupt.edu.cn</p>&nbsp&nbsp<a href="login.html">后台登录</a>
        </div>
    </div>
    <script>
        $(function () {
            $('#login1').on('click', function () {
                var id = $("#id").val();
                var pwd = $("#pwd").val();
                var radio = $("input[type='radio']");
                console.log(id + pwd);
                if (id === "" || pwd === "") {
                    alert("请输入账号和密码");
                    return false;
                } else {
                    if (radio[0].checked === true || radio[1].checked === true) {
                        var radiovalue = "";
                        if (radio[0].checked === true) {
                            radiovalue = radio[0].value;
                        } else {
                            radiovalue = radio[1].value;
                        }
                        $.ajax({
                            url: './login_.ashx',
                            async: true,
                            type: 'post',
                            data: { "id": id, "pwd": pwd, "status": radiovalue },
                            success: function (rlt) {
                                if (rlt === "false") {
                                    alert("请检查你的学号和密码是否正确");
                                    return false;
                                } else if (rlt === "true") {
                                    window.location.href = "TeacherIndex.aspx";
                                } else if (rlt === "index_true") {
                                    window.location.href = "index.aspx";
                                }
                                //} else {
                                //    window.location.href = "index.aspx";
                                //}
                            },
                            error: function () {
                            }
                        });
                    } else {
                        alert("请选择登录的身份");
                        return false;
                    }
                }
            });
        });
    </script>
    <script>
    var cas = document.getElementById("canvas");
console.log(cas);
var ctx=cas.getContext("2d");
draw();
cas.onclick=function(){
    ctx.clearRect(0,0,120,30);   //清空之前的矩形,释放空间
    draw();
    //随机4位数
}
//随机数方法
function ranbNum(min,max){
    var num=Math.floor(Math.random()*(max-min+1)+min);
    return num;
}
//绘制矩形
function draw(){
    ctx.fillStyle=ranbColor(170,250);   //这里背景色的取值范围为[170,250],颜色比较适中
    ctx.fillRect(0,0,120,30);    //绘制矩形
    var data='qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890';
    for(var i=0;i<120;i+=30){
        console.log('jjj');
        var c=data[ranbNum(0,data.length-1)]; //index为随机数,[0,data.length-1]  取字
        ctx.fillStyle=ranbColor(60,160);    //字体颜色
        ctx.font=ranbNum(15,40)+'px SimHei';  //字体大小,字体
        ctx.fillText(c,i+ranbNum(5,12),ranbNum(15,30));   //字体填充(字内容,x轴,y轴)
        console.log(c);
    }
    //绘制干扰线
    for (var i=0;i<10;i++) {
        ctx.beginPath(); //路径开始,子路经的集合
        ctx.moveTo(ranbNum(0,120),ranbNum(0,120));//起始点(x,y),都随机
        ctx.lineTo(ranbNum(0,120),ranbNum(0,120));//终止点(x,y)
        ctx.strokeStyle=ranbColor(60,160);//路径的颜色
        ctx.stroke();  //将上面的两个点连接起来
    }
    //绘制干扰点
    for (var i=0;i<10;i++) {
        ctx.beginPath(); //路径开始
        ctx.arc(ranbNum(0,120),ranbNum(0,30),ranbNum(1,5),0,2*Math.PI);//画圆(x,y,z,0,2*Math.PI) x坐标,y坐标,半径,完整圆
        ctx.strokeStyle=ranbColor(60,160);
        ctx.stroke();
    }
}
//颜色界于170到250,随机
function ranbColor(min,max){
    var r=Math.floor(Math.random()*(max-min+1)+min);//170+[0,80)
    var g=Math.floor(Math.random()*(max-min+1)+min);//170+[0,80)
    var b=Math.floor(Math.random()*(max-min+1)+min);//170+[0,80)
    return 'rgb('+r+','+g+','+b+')';
}
    </script>
</body>
</html>