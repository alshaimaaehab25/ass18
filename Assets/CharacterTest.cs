using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Position
    {
        public float X, Y, Z;

        public Position(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public void printPosition()
        {
            UnityEngine.Debug.Log($"X = {X}");
            UnityEngine.Debug.Log($" Y = {Y}");
            UnityEngine.Debug.Log($"Z = {Z}");
        }
    }

public class Character
    {
        public string name;
        private int health;
        protected Position position;
        public int Health
        {
            get { return health; }
            set { health = Mathf.Clamp(value, 0, 100); }
        }
        public Character(string name, int health, Position position)
        {
            this.name = name;
            this.Health = health;
            this.position = position;
        }
        public Character() : this("No name", 100, new Position(0, 0, 0)) {}
        public virtual void DisplayInfo()
        {
            UnityEngine.Debug.Log($"Name: {name}, Health: {Health}");
            position.printPosition();
        }
        public void Attack(int damage, Character target)
        {
            target.Health -= damage;
        }

        public void Attack(int damage, Character target, string attackType)
        {
            UnityEngine.Debug.Log($"Attack type: {attackType}");
            target.Health -= damage;
        }
    }

    public class Soldier : Character
    {
        public Soldier(string name, int health, Position position) : base(name, health, position) {}
        public override void DisplayInfo()
        {
            UnityEngine.Debug.Log("Soldier");
            base.DisplayInfo();
        }
    }

    public class Officer : Character
    {
        public Officer(string name, int health, Position position) : base(name, health, position) {}
        public override void DisplayInfo()
        {
            UnityEngine.Debug.Log("Officer");
            base.DisplayInfo();
        }
    }

    

public class CharacterTest : UnityEngine.MonoBehaviour
    {
        void Start()
        {
            Character[] characters = new Character[]
            {
                new Soldier("Soldier 1", 100, new Position(1, 2, 3)),
                new Officer("Officer 1", 80, new Position(4, 5, 6))
            };
            foreach (var character in characters)
            {
                character.DisplayInfo();
            }
            Officer officer = characters[1] as Officer;
            Soldier soldier = characters[0] as Soldier;

            if (officer != null && soldier != null)
            {
                UnityEngine.Debug.Log($"Soldier's Health before attack: {soldier.Health}");
                officer.Attack(20, soldier);
                UnityEngine.Debug.Log($"Soldier's Health after attack: {soldier.Health}");
            }
        }
    }