import React from 'react';
import './style.css';

export default function CreateTaskButton({ buttonText, handleCreateTaskFn = null, alignCenter = false }) {
  return (
    <button 
      onClick={handleCreateTaskFn}
      className='create-task-button' 
      type='button'
      style={{ alignSelf: alignCenter ? 'center' : 'flex-end' }}
    >
      {buttonText}
    </button>
  )
}
