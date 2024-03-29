var cas = document.getElementById("canvas");
console.log(cas);
var ctx=cas.getContext("2d");
draw();
cas.onclick=function(){
    ctx.clearRect(0,0,120,30);   //清空之前的矩形,释放空间
    draw();
    //随机4位数
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
//随机数方法
function ranbNum(min,max){
    var num=Math.floor(Math.random()*(max-min+1)+min);
    return num;
}
//绘制矩形
function draw(){
    ctx.fillStyle=ranbColor(170,250);   //这里背景色的取值范围为[170,250],颜色比较适中
    ctx.fillRect(0,0,120,30);    //绘制矩形
}
//颜色界于170到250,随机
function ranbColor(min,max){
    var r=Math.floor(Math.random()*(max-min+1)+min);//170+[0,80)
    var g=Math.floor(Math.random()*(max-min+1)+min);//170+[0,80)
    var b=Math.floor(Math.random()*(max-min+1)+min);//170+[0,80)
    return 'rgb('+r+','+g+','+b+')';
}