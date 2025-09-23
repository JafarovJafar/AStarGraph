using System;
using Shafir.FSM;

namespace Shafir.App
{
    public class ConstructorState : IState
    {
        public event Action ExitRequested;

        private AppContext _appContext;

        private CreateNodesState _createNodesState;
        private CreateEdgesState _createEdgesState;
        private DeleteEntitiesState _deleteEntitiesState;
        private SimpleStateMachine _stateMachine;

        public ConstructorState(AppContext appContext)
        {
            _appContext = appContext;

            _createNodesState = new CreateNodesState(_appContext);
            _createEdgesState = new CreateEdgesState(_appContext);
            _deleteEntitiesState = new DeleteEntitiesState(_appContext);
            _stateMachine = new SimpleStateMachine();
        }

        public void Enter()
        {
            _appContext.UserInput.SelectMode1Pressed += OnSelectMode1Pressed;
            _appContext.UserInput.SelectMode2Pressed += OnSelectMode2Pressed;
            _appContext.UserInput.SelectMode3Pressed += OnSelectMode3Pressed;
            _appContext.UserInput.CancelButtonPressed += OnCancelPressed;

            _stateMachine.ChangeState(_createNodesState);
        }

        public void Exit()
        {
            _appContext.UserInput.SelectMode1Pressed -= OnSelectMode1Pressed;
            _appContext.UserInput.SelectMode2Pressed -= OnSelectMode2Pressed;
            _appContext.UserInput.SelectMode3Pressed -= OnSelectMode3Pressed;
            _appContext.UserInput.CancelButtonPressed -= OnCancelPressed;

            _stateMachine.CurrentState.Exit();
        }

        private void OnSelectMode1Pressed()
        {
            _stateMachine.ChangeState(_createNodesState);
        }

        private void OnSelectMode2Pressed()
        {
            _stateMachine.ChangeState(_createEdgesState);
        }

        private void OnSelectMode3Pressed()
        {
            _stateMachine.ChangeState(_deleteEntitiesState);
        }

        private void OnCancelPressed()
        {
            ExitRequested?.Invoke();
        }
    }
}