using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_OOP2_cv_080_Inventory
{
    internal class Combat
    {
        public Character Fighter1 { get; private set; }
        public Character Fighter2 { get; private set; }

        private ILogger _logger;

        public Combat(Character fighter1, Character fighter2, ILogger logger)
        {
            Fighter1 = fighter1;
            Fighter2 = fighter2;
            _logger = logger;
        }

        public void Fight()
        {
            Dice coin = new Dice(2);
            
            Character attacker, defender;
            int attack, wound;

            _logger.Log($"Combat {Fighter1.Name} ({Fighter1.HP} HP) vs. {Fighter2.Name} ({Fighter2.HP} HP)");

            while(Fighter1.HP > 0 && Fighter2.HP > 0) {

                _logger.Log($"State: {Fighter1.Name} {Fighter1.HP} HP, {Fighter2.Name} {Fighter2.HP} HP");

                //vybereme, kdo utoci, kdo se brani
                if (coin.Throw() == 1)
                {
                    attacker = Fighter1;
                    defender = Fighter2;
                }
                else
                {
                    attacker = Fighter2;
                    defender = Fighter1;
                }

                //probehne utok
                attack = attacker.Attack();
                wound = defender.ManageAttack(attack);
                if (wound > 0 )
                    _logger.Log($"{attacker.Name} rolls {attack} and hits {defender.Name} for {wound} HP.");
                else
                    _logger.Log($"{attacker.Name} rolls {attack} and misses {defender.Name}.");

                if (defender.HP <= 0)
                    break;

                //otocime role
                (attacker, defender) = (defender, attacker);

                //probehne utok
                attack = attacker.Attack();
                wound = defender.ManageAttack(attack);
                if (wound > 0)
                    _logger.Log($"{attacker.Name} rolls {attack} and hits {defender.Name} for {wound} HP.");
                else
                    _logger.Log($"{attacker.Name} rolls {attack} and misses {defender.Name}.");
            }

            Character victor = this.Victor;
            _logger.Log($"{victor.Name} wins with {victor.HP} / {victor.MaxHP} HP remaining.");
        }
        public Character Victor
        {
            get
            {
                if (Fighter1.HP > 0 && Fighter2.HP > 0)
                    return null;
                else if (Fighter1.HP > 0)
                    return Fighter1;
                else
                    return Fighter2;
            }
        }
    }
}
