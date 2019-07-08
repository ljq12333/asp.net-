<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminManage.aspx.cs" Inherits="选题系统.adminManage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  <link rel="stylesheet" href="css/common.css"/>
  <link rel="stylesheet" href="css/style.css"/>
  <script type="text/javascript" src="js/jquery.min.js"></script>
  <script type="text/javascript" src="js/jquery.SuperSlide.js"></script>
  <script type="text/javascript">
  $(function(){
      $(".sideMenu").slide({
         titCell:"h3", 
         targetCell:"ul",
         defaultIndex:0, 
         effect:'slideDown', 
         delayTime:'500' , 
         trigger:'click', 
         triggerTime:'150', 
         defaultPlay:true, 
         returnDefault:false,
         easing:'easeInQuint',
         endFun:function(){
              scrollWW();
         }
       });
      $(window).resize(function() {
          scrollWW();
      });
  });
  function scrollWW(){
    if($(".side").height()<$(".sideMenu").height()){
       $(".scroll").show();
       var pos = $(".sideMenu ul:visible").position().top-38;
       $('.sideMenu').animate({top:-pos});
    }else{
       $(".scroll").hide();
       $('.sideMenu').animate({top:0});
       n=1;
    }
  } 

var n=1;
function menuScroll(num){
  var Scroll = $('.sideMenu');
  var ScrollP = $('.sideMenu').position();
  /*alert(n);
  alert(ScrollP.top);*/
  if(num===1){
     Scroll.animate({top:ScrollP.top-38});
     n = n+1;
  }else{
    if (ScrollP.top > -38 && ScrollP.top !== 0) { ScrollP.top = -38; }
    if (ScrollP.top<0) {
      Scroll.animate({top:38+ScrollP.top});
    }else{
      n=1;
    }
    if(n>1){
      n = n-1;
    }
  }
}
  </script>
          <style>
              .sideMenu > ul > li:hover {
                    cursor:pointer;
              }
          </style>
  <title>后台首页</title>
    <style>
        .info_center {
            padding-top:10px;
        }
    </style>
</head>
<body>
    <div class="top" runat="server">
      <div id="top_t">
        <div id="logo" class="fl"></div>
        <div id="photo_info" class="fr">
          <div id="photo" class="fl">
            <a href="#"><img src="images/a.png" alt="" width="60" height="60"></a>
          </div>
          <div id="base_info" class="fr">
            <div class="help_info">
              <a href="1" id="hp">&nbsp;</a>
              <a href="2" id="gy">&nbsp;</a>
              <a href="Alllogin.aspx" id="out" runat="server" name="out">&nbsp;</a>
            </div>
            <div class="info_center">
              <span id="user" runat="server"></span>
              <span id="nt" runat="server" name="status"></span>
            </div>
          </div>
        </div>
      </div>
      <div id="side_here">
        <div id="side_here_l" class="fl"></div>
        <div id="here_area" class="fl">当前位置：</div>
      </div>
    </div>
    <div class="side">
        <div class="sideMenu" style="margin:0 auto">
          <h3>添加</h3>
          <ul>
            <li class="insert_stu">添加学生</li>
            <li class="insert_tea">添加老师</li>
          </ul>
            <h3>管理</h3>
           <ul>
               <li id="stu_manage">学生管理</li>
               <li id="tea_manage">老师管理</li>
           </ul>
       </div>
    </div>
    <div class="main">
       <iframe name="right" id="rightMain" src="insert_tea.html" frameborder="no" scrolling="auto" width="100%" height="auto" allowtransparency="true"></iframe>
    </div>
    <div class="bottom">
      <div id="bottom_bg">版权</div>
    </div>
    <div class="scroll">
          <a href="javascript:;" class="per" title="使用鼠标滚轴滚动侧栏" onclick="menuScroll(1);"></a>
          <a href="javascript:;" class="next" title="使用鼠标滚轴滚动侧栏" onclick="menuScroll(2);"></a>
    </div>
    <script>
        $(".insert_stu").on("click", function () {
            $("iframe").attr("src", "insert_stu.html");
        });
        $(".insert_tea").on("click", function () {
            $("iframe").attr("src", "insert_tea.html");
        });
        $("#stu_manage").on("click", function () {
            $("iframe").attr("src", "manage_del_stu.html");
        });
        $("#tea_manage").on("click", function () {
            $("iframe").attr("src", "manage_del_tea.html");
        });
    </script>
    </body>
    </html>
