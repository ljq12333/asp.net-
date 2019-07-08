using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODEL;
using System.Data;
namespace DAL
{
   public class stuDal
    {
        public static bool insert_pro(stu_insert stu_Insert) {
            string sql = "insert into stu_insert_info(stu_num,teacher,project_name,project_info) values('" + stu_Insert.stu_num + "','" + stu_Insert.tea_name + "','" + stu_Insert.project_name + "','" + stu_Insert.project_info + "')";
            return sqlHeleper.all(sql);
        }
        public static bool updateIsYes(string name) {
            string sql = "update project set IsChoose='是' where project_name='" + name + "'";
            return sqlHeleper.all(sql);
        }
        public static bool updateIsNo(string name)
        {
            string sql = "update project set IsChoose='是' where project_name='" + name + "'";
            return sqlHeleper.all(sql);
        }
        public static DataSet select_project_count(stu_insert stu_Insert) {
            string sql = "select * from stu_insert_info where stu_num='" + stu_Insert.stu_num + "'";
            return sqlHeleper.selectAll(sql);
        }
        public static DataSet select_stu_pwd(student student) {
            string sql = "select * from stu_info where stu_num='" + student.stu_num + "'and pwd='" + student.pwd + "'";
            return sqlHeleper.selectAll(sql);
        }
        public static DataSet select_tea_pwd(Teacher teacher) {
            string sql = "select * from teacher_info where teacher_num='" + teacher.teacher_num + "'and pwd='" + teacher.pwd + "'";
            return sqlHeleper.selectAll(sql);
        }
        public static DataSet select_stu_name(student student) {
            string sql = "select stu_name from stu_info where stu_num='" + student.stu_num + "'";
            return sqlHeleper.selectAll(sql);
        }
        public static DataSet select_tea_name(Teacher teacher) {
            string sql = "select teacher_name from teacher_info where teacher_num='" + teacher.teacher_num + "'";
            return sqlHeleper.selectAll(sql);
        }
        public static bool tea_insert_project(project project) {
            string sql = "insert into project(tea_num,tea_name,project_name,project_info,IsChoose) values('" + project.teacher_num + "','" + project.teacher_name + "','" + project.project_name + "','" + project.project_info + "','否')";
            return sqlHeleper.all(sql);
        }
        public static DataSet tea_select_project(project project) {
            string sql = "select project_name,project_info from project where tea_num='" + project.teacher_num + "'";
            return sqlHeleper.selectAll(sql);
        }
        public static bool tea_update_project(project project) {
            string sql = "update project set project_info='" + project.project_info + "' where project_name='" + project.project_name + "'and tea_num='" + project.teacher_num + "'";
            return sqlHeleper.all(sql);
        }
        public static bool tea_del_project(project project) {
            string sql = "delete from project where project_name='" + project.project_name + "'and tea_num='" + project.teacher_num + "'";
            return sqlHeleper.all(sql);
        }
        public static DataSet select_teaName(Teacher teacher) {
            string sql = "select stu_insert_info.project_name , stu_info.stu_name ,stu_info.class from stu_info, stu_insert_info where stu_info.stu_num=stu_insert_info.stu_num and stu_insert_info.teacher='" + teacher.teacher_name + "'";
            return sqlHeleper.selectAll(sql);
        }
        public static bool stu_del_projectName(stu_insert stu_Insert) {
            string sql = "delete from stu_insert_info where project_name='" + stu_Insert.project_name + "'";
            return sqlHeleper.all(sql);
        }
        public static bool update_pwd(student student) {
            string sql = "update stu_info set pwd='" + student.pwd + "'where stu_num='" + student.stu_num + "'";
            return sqlHeleper.all(sql);
        }
        public static DataSet select_stuinfo(stu_insert stu_Insert) {
            string sql = "select * from stu_insert_info where stu_num='" + stu_Insert.stu_num + "'";
            return sqlHeleper.selectAll(sql);
        }
        public static bool del_stu_info_insert(stu_insert stu_Insert) {
            string sql = "delete from stu_insert_info where stu_num='" + stu_Insert.stu_num + "'";
            return sqlHeleper.all(sql);
        }
        public static bool insert_stu(student student) {
            string sql = "insert into stu_info(stu_num,stu_name,class,pwd) values('"+student.stu_num+"','"+student.stu_name+"','"+student.className+"','"+student.pwd+"')";
            return sqlHeleper.all(sql);
        }
        public static bool insert_tea(Teacher teacher) {
            string sql = "insert into teacher_info(teacher_num,teacher_name,pwd)values('"+teacher.teacher_num+"','"+teacher.teacher_name+"','"+teacher.pwd+"')";
            return sqlHeleper.all(sql);
        }
        public static DataSet login_tea(admin admin) {
            string sql = "select * from manage where username='" + admin.username + "'and pwd='" + admin.pwd + "'";
            return sqlHeleper.selectAll(sql);
        }
        public static DataSet selectAll_stu() {
            string sql = "select * from stu_info";
            return sqlHeleper.selectAll(sql);
        }
        public static DataSet selectAll_tea() {
            string sql = "select * from teacher_info";
            return sqlHeleper.selectAll(sql);
        }
        public static bool del_stu(student student) {
            string sql = "delete from stu_info where stu_num='"+student.stu_num+"'";
            return sqlHeleper.all(sql);
        }
        public static bool del_tea(Teacher teacher) {
            string sql = "delete from teacher_info where teacher_num='" + teacher.teacher_num + "'";
            return sqlHeleper.all(sql);
        }
        public static bool del_tea_pro(Teacher teacher) {
            string sql = "delete from stu_insert_info where teacher ='(select teacher_name from teacher_info teacher_num='" + teacher.teacher_num + "')'";
            return sqlHeleper.all(sql);
        }
        public static bool del_pro(project project) {
            string sql ="delete from project where tea_num='"+project.teacher_num+"'";
            return sqlHeleper.all(sql);
        }
    }
}
