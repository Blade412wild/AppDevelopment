using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FirstAppGame.ActionStateManager;

namespace FirstAppGame
{
    class StatsCalculators
    {

        public float IncreaseHungerAndThirst(float _currentStatAmount, float _timePast)
        {
            float _baseAmount;
            float _newAmount;

            if (_currentStatAmount < 100)
            {
                _baseAmount = +100.0f / 3.0f / 60.0f / 60.0f; //je hebt 3 uur(3 maaltijden) nodig om hem helemaal vol te krijgen
            }
            else
            {
                _baseAmount = 0.0f;
                _newAmount = 100.0f;
            }

            _newAmount = _currentStatAmount + (_baseAmount * _timePast);

            return _newAmount;
        }
        public float DecreaseHungerAndThirst(float _currentStatAmount, float _timePast)
        {
            float _baseAmount;
            float _newAmount; ;

            if (_currentStatAmount > 0)
            {
                _baseAmount = -100.0f / 24.0f / 60.0f / 60.0f; //per dag gaat het helemaal leeg

            }
            else
            {
                _baseAmount = 0.0f;
                _newAmount = 0.0f;
            }

            _newAmount = _currentStatAmount + (_baseAmount * _timePast);

            return _newAmount;
        }
        public float IncreaseEnergy(float _currentStatAmount, float _timePast)
        {
            float _baseAmount;
            float _newAmount;

            if (_currentStatAmount < 100.0f)
            {
                _baseAmount = 100.0f / 8 / 60 / 60; //per dag gaat het helemaal leeg
            }
            else
            {
                _baseAmount = 0.0f;
                _newAmount = 100.0f;
            }

            _newAmount = _currentStatAmount + (_baseAmount * _timePast);

            return _newAmount;
        }
        public float DecreaseEnergy(float _currentStatAmount, float _timePast)   
        {
            float _baseAmount;
            float _newAmount;

            if (_currentStatAmount > 0)
            {
                _baseAmount = -100.0f / 24 / 60 / 60; //per dag gaat het helemaal leeg
            }
            else
            {
                _baseAmount = 0.0f;
                _newAmount = 0.0f;
            }

            _newAmount = _currentStatAmount + (_baseAmount * _timePast);

            return _newAmount;
        }
        public float IncreaseMoney(float _currentStatAmount, float _timePast)
        {
            float loanPerSeconds = 12.50f / 60.0f / 60.0f;// uurloon = 12,50 
            return loanPerSeconds * _timePast;
        }
        public float DecreaseMoney(PlayerAction _playerAction, float _currentStatAmount, float _timePast)
        {
            float _eatingCost = 0;
            float _gamingCost = 0;
            float _livingCost = -50.0f / 24 / 60 / 60; // 50 euro per dag = 24 uur 

            if (_playerAction == PlayerAction.Eating)
            {
                _eatingCost = -15.0f / 60 / 60;// 15 euro per maal = 1 uur
            }

            if (_playerAction == PlayerAction.Gaming)
            {
                _gamingCost = -1.0f / 60 / 60; // 1 euro per uur
            }

            float _newAmount = _currentStatAmount + _timePast * (_livingCost + _gamingCost + _eatingCost);

            return _newAmount;
        }
        public float IncreaseOverstimulation(float _currentStatAmount, float _timePast)
        {
            float _baseAmount;
            float _newAmount; ;

            if (_currentStatAmount < 100.0f)
            {
                _baseAmount = 80.0f / 8 / 60 / 60; //je 20% over na een dag werken(8h)
                _newAmount = _baseAmount;

            }
            else
            {
                _baseAmount = 0.0f;
                _newAmount = 100.0f;
            }

            _newAmount = _currentStatAmount + (_baseAmount * _timePast);

            return _newAmount;
        }
        public float DecreaseOverstimulation(PlayerAction _playerState, float _currentStatAmount, float _timePast)
        {
            float _sleepEffect = 0;
            float _gamingEffect = 0;
            float _newAmount;

            if (_currentStatAmount > 0.0f)
            {
                if (_playerState == PlayerAction.Sleeping)
                {
                    _sleepEffect = -30.0f / 8 / 60 / 60; // speler verminderd met 30 als hij 8 uur slaapt
                }

                if (_playerState == PlayerAction.Gaming)
                {
                    _gamingEffect = -50.0f / 2 / 60 / 60;
                }
            }
            else
            {
                _sleepEffect = 0;
                _gamingEffect = 0;
                _newAmount = 0.0f;
            }


            _newAmount = _currentStatAmount + _timePast * (_sleepEffect + _gamingEffect);

            return _newAmount;
        }
        public float IncreaseBoredNess(float _currentStatAmount, float _timePast)
        {
            float _baseAmount;
            float _newAmount;

            if (_currentStatAmount < 100.0f)
            {
                _baseAmount = 60.0f / 8 / 60 / 60; //je 40% over na een dag werken(8h) 
            }
            else
            {
                _baseAmount = 0.0f;
                _newAmount = 100.0f;
            }

            _newAmount = _currentStatAmount + (_baseAmount * _timePast);

            return _newAmount;
        }
        public float DecreaseBoredNess(float _currentStatAmount, float _timePast)
        {
            float _baseAmount;
            float _newAmount;

            if (_currentStatAmount > 0)
            {
                _baseAmount = -40.0f / 2 / 60 / 60; //je krijgt na 2 uur gamen de 40% weer terug 
            }
            else
            {
                _baseAmount = 0.0f;
                _newAmount = 0.0f;
            }

            _newAmount = _currentStatAmount + (_baseAmount * _timePast);

            return _newAmount;
        }
        public float IncreaseLonely(float _currentStatAmount, float _timePast)
        {
            float _baseAmount;
            float _newAmount;

            if (_currentStatAmount < 100.0f)
            {
                _baseAmount = 100.0f / 24 / 60 / 60; //je moet je  elke dag zien
            }
            else
            {
                _baseAmount = 0.0f;
                _newAmount = 0.0f;
            }

            _newAmount = _currentStatAmount + (_baseAmount * _timePast);

            return _newAmount;
        }
        public float DecreaseLonely(float _currentStatAmount, float _timePast)
        {
            float _baseAmount;
            float _newAmount;

            if (_currentStatAmount > 0)
            {
                _baseAmount = -100.0f / 0.1f / 60 / 60; // als je een 6 min online bent is hij helemaal blij 
            }
            else
            {
                _baseAmount = 0.0f;
                _newAmount = 0.0f;
            }

            _newAmount = _currentStatAmount + (_baseAmount * _timePast);

            return _newAmount;
        }











    }
}
