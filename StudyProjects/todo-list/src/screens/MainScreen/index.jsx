import React, { useEffect, useState } from 'react';
import './style.css';
import TodoListBox from '../../components/TodoListBox';
import CreateTaskButton from '../../components/CreateTaskButton';
import WriteTaskModal from '../../components/WriteTaskModal';

export default function MainScreen() {
    const [tasks, setTasks] = useState([
        { id: 0, text: 'Começar a execução do projeto', isComplete: false },
        { id: 1, text: 'Começar a execução do projeto', isComplete: true }
    ]);

    const [filteredTasks, setFilteredTasks] = useState([]);

    const [editingTask, setEditingTask] = useState(null);

    const [isWriteTaskModalOpen, setIsWriteTaskModalOpen] = useState(false);

    const [titleFilter, setTitleFilter] = useState('');

    function openWriteTaskModal() {
        setIsWriteTaskModalOpen(true);
    }

    function closeWriteTaskModal() {
        setIsWriteTaskModalOpen(false);
    }

    function addTask(taskDescription) {
        const newTask = { 
            id: tasks.length,
            text: taskDescription,
            isComplete: false
        } 

        setTasks([...tasks, newTask]);

        closeWriteTaskModal()
    }
    
    function deleteTask(taskId) {
        setTasks(tasks.filter(task => task.id !== taskId));
    }
    
    function doneTask(taskId) {
        setTasks(tasks.map(task => {
            if (task.id === taskId) {
                return {
                    ...task,
                    isComplete: !task.isComplete
                };
            }

            return task;
        }))
    }
    
    function startToEditTask(task) {
        setEditingTask(task);

        openWriteTaskModal();
    }

    function updateTask(taskDescription) {
        setTasks(tasks.map(task => {
            if (task.id === editingTask.id) {
                return {
                    ...task,
                    text: taskDescription
                };
            }

            return task;
        }))

        setEditingTask(null);

        closeWriteTaskModal();
    }

    useEffect(() => {
        if (titleFilter === '') {
            setFilteredTasks(tasks);
        } else {
            const regex = new RegExp(titleFilter, 'gi');
            setFilteredTasks(tasks.filter(task => task.text.match(regex)))
        }

    }, [titleFilter, tasks])
    
    return (
        <>
            <WriteTaskModal 
                isOpen={isWriteTaskModalOpen}
                editingTask={editingTask}
                handleCloseModalFn={!editingTask ? addTask : updateTask} 
            />
            <div className='background'>
                <div className="background-content">
                    <TodoListBox 
                        tasks={filteredTasks}
                        handleTaskDeleteFn={deleteTask}
                        handleDoneTaskFn={doneTask}
                        handleTaskEditFn={startToEditTask}
                        titleFilter={titleFilter}
                        setTitleFilter={setTitleFilter}
                    />
                    <CreateTaskButton 
                        buttonText='Nova tarefa'
                        handleCreateTaskFn={openWriteTaskModal} 
                    />
                </div>
            </div>
        </>
    )
}
