import React, { useEffect, useState } from 'react';
import Modal from 'react-modal';
import './style.css';
import CreateTaskButton from '../CreateTaskButton';

Modal.setAppElement('#root');

export default function WriteTaskModal({ isOpen = false, handleCloseModalFn = null, editingTask = null }) {
  const [taskDescription, setTaskDescription] = useState('');

  useEffect(() => {
    if (editingTask) {
      setTaskDescription(editingTask.text);
    }
  }, [editingTask]);

  return (
    <div>
        <Modal 
            isOpen={isOpen}
            style={{
              content : {
                backgroundColor: '#1E123B',
                width: '60%',
                height: '70%',
                borderRadius: 10,
                top: '50%',
                left: '50%',
                right: 'auto',
                bottom: 'auto',
                marginRight: '-50%',
                transform: 'translate(-50%, -50%)',
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center',
                justifyContent: 'space-between',
                paddingTop: 50,
                paddingBottom: 50,
                border: 'none',
              },
              overlay: {
                backgroundColor: '#8758FFDD',
              }
            }}
        >
            <h2 className="task-modal-title">{editingTask ? 'Edite sua tarefa' : 'Descreva sua tarefa'}</h2>
            <textarea
              rows="10"
              cols="60" 
              type='text'
              value={taskDescription}
              onChange={e => setTaskDescription(e.target.value)}
              placeholder='Digite aqui a descrição da sua tarefa...' 
              className="task-description-input"
            ></textarea>
            <CreateTaskButton 
              buttonText={editingTask ? 'Confirmar edição' : 'Confirmar tarefa'}
              handleCreateTaskFn={() => {
                if (taskDescription !== '') {
                  handleCloseModalFn(taskDescription);
                  setTaskDescription('');
                }
              }}
              alignCenter={true}
            />
        </Modal>
    </div>
  )
}
