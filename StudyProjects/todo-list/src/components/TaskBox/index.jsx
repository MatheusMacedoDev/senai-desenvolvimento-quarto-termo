import React from 'react';
import './style.css';

import { FaCheck } from "react-icons/fa";
import { IoClose } from "react-icons/io5";
import { FaPencil } from "react-icons/fa6";

export default function TaskBox({description = '', isTaskComplete = false, handleTaskDeleteFn = null, handleDoneTaskFn = null, handleTaskEditFn = null}) {
    return (
        <article className={`task-box-background${isTaskComplete ? ' task-complete-style' : ''}`}>
            <div 
                className={`checkbox${isTaskComplete ? ' checked' : ''}`}
                onClick={handleDoneTaskFn}
            >
                {isTaskComplete ? (
                    <FaCheck style={{marginLeft: 1}} color='#FAFAFA' />
                ) : null}
            </div>
            <h3 className={`task-description${isTaskComplete ? ' task-description-light' : ''}`}>{description}</h3>
            <div className="action-buttons-group">
                <button 
                    onClick={handleTaskDeleteFn} 
                    className={`button-background${isTaskComplete ? ' button-background-light' : ''}`} type="button"
                >
                    <IoClose size={24} color={isTaskComplete ? '#FFFFFF' : '#1E123B'} />
                </button>
                <button 
                    onClick={handleTaskEditFn}
                    className={`button-background${isTaskComplete ? ' button-background-light' : ''}`} type="button"
                >
                    <FaPencil size={16} color={isTaskComplete ? '#FFFFFF' : '#1E123B'} />
                </button>
            </div>
        </article>
    )
}
