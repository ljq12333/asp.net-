﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeacherIndex.aspx.cs" Inherits="选题系统.teacher" %>

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
    if (ScrollP.top > -38 && ScrollP.top != 0) { ScrollP.top = -38; }
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
        .info_center {
            padding-top:10px;
        }
          </style>
  <title>后台首页</title>
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
              <a href="3" id="out">&nbsp;</a>
            </div>
            <div class="info_center">
              <span id="teacher_id" runat="server"></span>
              <span id="nt" runat="server"></span>
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
          <h3>课题管理</h3>
          <ul>
            <li id="insert_project">增加课题</li>
            <li id="de_up_project">删除修改课题</li>
          </ul>
          <h3> 学生信息</h3>
          <ul>
            <li id="stu_manage">选课学生</li>
          </ul>
       </div>
    </div>
    <div class="main">
       <iframe name="right" id="rightMain" src="del_up_project.html" frameborder="no" scrolling="auto" width="100%" height="auto" allowtransparency="true"></iframe>
    </div>
    <div class="bottom">
      <div id="bottom_bg">版权</div>
    </div>
    <div class="scroll">
          <a href="javascript:;" class="per" title="使用鼠标滚轴滚动侧栏" onclick="menuScroll(1);"></a>
          <a href="javascript:;" class="next" title="使用鼠标滚轴滚动侧栏" onclick="menuScroll(2);"></a>
    </div>
    <script>
        $(function () {
             $("#out").on("click", function () {
                $.ajax({
                    url: "./out.ashx",
                    type: "post",
                    async: true,
                    data: { "url": "teacher" },
                    success: function (rlt) {
                        if (rlt === "退出成功") {
                            console.log("hello");
                            window.location.href = "Alllogin.aspx";
                        } else {
                            alert("退出失败");
                            return false;
                        }
                    },
                    error: function (e) {
                        console.log(e);
                    }
                });
            });
            $('#insert_project').on("click", function () {
                $("iframe").attr("src", "project_ins.html");
            });
            $('#de_up_project').on("click", function () {
                $("iframe").attr("src", "del_up_project.html").toggleClass('');
            });
            $("#stu_manage").on("click", function () {
                $("iframe").attr("src", "tea_stu_manage.html");
            });
        });
    </script>
</body>
</html>
 