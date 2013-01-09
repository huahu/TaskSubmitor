﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VssHelper;

namespace BLL
{
    /// <summary>
    /// 用于检入检出操作
    /// 作者：ChengNing
    /// 日期：2013-01-06
    /// </summary>
    public class CheckBLL
    {
        private VssHelper.VssHelper vssHelper;
        private string vssDir;
        private string localDir;


        public CheckBLL()
        { 
        }

        public CheckBLL(string vssUser,string vssPwd,string vssUrl,string vssDir,string localDir)
        {
            this.vssHelper = new VssHelper.VssHelper();
            this.vssHelper.Username = vssUser;
            this.vssHelper.Password = vssPwd;
            this.vssHelper.SrcSafeIni = vssUrl;

            this.vssDir = vssDir;
            this.localDir = localDir;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName">文件相对路径，eg：ui\sys\file.java</param>
        /// <param name="comment"></param>
        public void CheckOut(string fileName,string comment)
        {
            string vssPath = this.vssDir.Trim('/') + "/" + fileName.Trim('/');
            string localPath = this.localDir.Trim('\\') + @"\" + fileName.Trim('\\');
            this.vssHelper.CheckOut(vssPath, localPath, comment);
        }

        /// <summary>
        /// 参见同名CheckOut方法说明
        /// </summary>
        /// <param name="fileNameList"></param>
        /// <param name="comment"></param>
        public void CheckOut(string[] fileNameList, string comment)
        {
            foreach (string file in fileNameList)
            {
                CheckOut(file, comment);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileNameList"></param>
        /// <param name="comment"></param>
        public void CheckIn(string[] fileNameList, string comment)
        {
            foreach (string file in fileNameList)
            {
                CheckIn(file, comment);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="comment"></param>
        public void CheckIn(string fileName, string comment)
        {
            string vssPath = this.vssDir.Trim('/') + "/" + fileName.Trim('/');
            string localPath = this.localDir.Trim('\\') + @"\" + fileName.Trim('\\');
            this.vssHelper.CheckIn(localPath,vssPath, comment);
        }
    }
}
