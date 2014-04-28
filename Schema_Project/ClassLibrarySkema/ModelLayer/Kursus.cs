﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrarySkema.ModelLayer
{
    public class Kursus
    {
        public string KursusKode { get; private set; }
        public string KursusName { get; private set; }
        public List<Module> Modules { get; private set; }
        public List<Hold> HoldObjs { get; private set; }
        public Laerer LaererObj { get; private set; }

        //public Kursus(string code, string name, int moduleCount, List<string> holdCodes, string teacherCode, IMoodle moodle)
        //{
        //    this.KursusKode = code;
        //    this.KursusName = name;
        //    this.Modules = Enumerable.Range(1, moduleCount)
        //                             .Select(moduleNumber => 
        //                                 new Module() { 
        //                                     ModuleNumber = moduleNumber, 
        //                                     KursusObj = this 
        //                                 }).ToList();
        //    this.HoldObjs = holdCodes.Select(holdCode => moodle.LookupHold(holdCode)).ToList();
        //    this.LaererObj = moodle.LookupTeacher(teacherCode);
        //}


        public Kursus(string code, string name, int moduleCount, List<string> holdCodes, string teacherCode, IMoodle moodle)
        {
            this.KursusKode = code;
            this.KursusName = name;
            this.Modules = new List<Module>();
            for (int i = 0; i < moduleCount; i++)
                this.Modules.Add(new Module() { ModuleNumber = i, KursusObj = this });
            this.HoldObjs = new List<Hold>();
            foreach (string holdCode in holdCodes)
                this.HoldObjs.Add(moodle.LookupHold(holdCode));
            this.LaererObj = moodle.LookupTeacher(teacherCode);
        }

        //public Kursus(string code, string name, int moduleCount, List<Hold> hold, Laerer teacher)
        //{
        //    this.KursusKode = code;
        //    this.KursusName = name;
        //    this.Modules = new List<Module>();
        //    for (int i = 0; i < moduleCount; i++)
        //        this.Modules.Add(new Module() { ModuleNumber = i, KursusObj = this });
        //    this.HoldObjs = hold;
        //    this.LaererObj = teacher;
        //}

        public override string ToString()
        {
            return string.Format("Kursus - Code: {0}, Name: {1}, Teacher: {2}, ModuleCount: {3}, Hold: {4}", KursusKode, KursusName, LaererObj.LaererKode, Modules.Count(), string.Join(", ", HoldObjs.Select(h => h.HoldCode)));
        }
    }
}
