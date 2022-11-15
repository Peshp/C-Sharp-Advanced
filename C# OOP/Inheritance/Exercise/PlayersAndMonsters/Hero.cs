using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero
    {
        private string username;
        private int level;
        public Hero(string userName, int level)
        {
            this.UserName = userName;
            this.Level = level;
        }
        public string UserName
        {
            get { return this.username; }
            set { this.username = value; }
        }
        public int Level
        {
            get { return this.level; }
            set { this.level = value; }
        }
        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.UserName} Level: {this.Level}";
        }      
    }
    public class Elf : Hero
    {
        public Elf(string userName, int level) : base(userName, level)
        { }
    }
    public class MuseElf : Elf
    {
        public MuseElf(string userName, int level) : base(userName, level)
        { }
    }
    public class Wizard : Hero
    {
        public Wizard(string userName, int level) : base(userName, level)
        { }
    }
    public class DarkWizard : Wizard
    {
        public DarkWizard(string userName, int level) : base(userName, level)
        { }
    }
    public class SoulMaster : DarkWizard
    {
        public SoulMaster(string userName, int level) : base(userName, level)
        { }
    }
    public class Knight : Hero
    {
        public Knight(string userName, int level) : base(userName, level)
        { }
    }
    public class DarkKnight : Knight
    {
        public DarkKnight(string userName, int level) : base(userName, level)
        { }
    }
    public class BladeKnight : DarkKnight
    {
        public BladeKnight(string userName, int level) : base(userName, level)
        { }
    }
}
