using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using MODEL;
using System.Data;
namespace BLL
{
    public class stuBll
    {
        public static bool insert_pro(stu_insert stu_Insert)
        {
            if (DAL.stuDal.insert_pro(stu_Insert) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool updateIsYes(string name)
        {
            if (DAL.stuDal.updateIsYes(name) == true)
            {
                return true;
            }
            else {
                return false;
            }
        }
        public static bool updateIsNo(string name)
        {
            if (DAL.stuDal.updateIsNo(name) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static DataSet select_project_count(stu_insert stu_Insert)
        {
            DataSet ds = DAL.stuDal.select_project_count(stu_Insert);
            return ds;
        }
        public static DataSet select_teacher_pwd(Teacher teacher)
        {
            DataSet ds = DAL.stuDal.select_tea_pwd(teacher);
            return ds;
        }
        public static DataSet select_stu_pwd(student student)
        {
            DataSet ds = DAL.stuDal.select_stu_pwd(student);
            return ds;
        }
        public static DataSet select_stu_name(student student)
        {
            DataSet ds = DAL.stuDal.select_stu_name(student);
            return ds;
        }
        public static DataSet select_tea_name(Teacher teacher)
        {
            DataSet ds = DAL.stuDal.select_tea_name(teacher);
            return ds;
        }
        public static bool tea_insert_project(project project)
        {
            return DAL.stuDal.tea_insert_project(project);
        }
        public static DataSet tea_select_project(project project)
        {
            return DAL.stuDal.tea_select_project(project);
        }
        public static bool tea_update_project(project project)
        {
            return DAL.stuDal.tea_update_project(project);
        }
        public static bool tea_del_project(project project)
        {
            return DAL.stuDal.tea_del_project(project);
        }
        public static DataSet select_teaName(Teacher teacher)
        {
            return DAL.stuDal.select_teaName(teacher);
        }
        public static bool stu_del_projectName(stu_insert stu_Insert)
        {
            return DAL.stuDal.stu_del_projectName(stu_Insert);
        }
        public static bool update_pwd(student student)
        {
            return DAL.stuDal.update_pwd(student);
        }
        public static DataSet select_stuinfo(stu_insert stu_Insert)
        {
            return DAL.stuDal.select_stuinfo(stu_Insert);
        }
        public static bool del_stu_info_insert(stu_insert stu_Insert)
        {
            return DAL.stuDal.del_stu_info_insert(stu_Insert);
        }
        public static bool insert_stu(student student)
        {
            return DAL.stuDal.insert_stu(student);
        }
        public static bool insert_tea(Teacher teacher)
        {
            return DAL.stuDal.insert_tea(teacher);
        }
        public static DataSet login_tea(admin admin)
        {
            return DAL.stuDal.login_tea(admin);
        }
        public static DataSet selectAll_stu()
        {
            return DAL.stuDal.selectAll_stu();
        }
        public static DataSet selectAll_tea()
        {
            return DAL.stuDal.selectAll_tea();
        }
        public static bool del_stu(student student)
        {
            return DAL.stuDal.del_stu(student);
        }
        public static bool del_tea(Teacher teacher)
        {
            return DAL.stuDal.del_tea(teacher);
        }
        public static bool del_tea_pro(Teacher teacher)
        {
            return DAL.stuDal.del_tea_pro(teacher);
        }
        public static bool del_pro(project project)
        {
            return DAL.stuDal.del_pro(project);
        }
    }
}