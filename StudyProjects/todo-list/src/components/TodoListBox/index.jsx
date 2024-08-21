import React, { useState } from 'react';
import './style.css'
import DateView from '../DateView';
import SearchInput from '../SearchInput';
import TaskBox from '../TaskBox';

export default function TodoListBox({ tasks = [], handleTaskDeleteFn = null, handleDoneTaskFn = null, handleTaskEditFn = null, titleFilter, setTitleFilter }) {
  return (
    <section className='box-background'>
        <DateView />
        <SearchInput text={titleFilter} setText={setTitleFilter} />
        {
            tasks ? (
                <main className='todo-main'>
                    {
                        tasks.map(element => (
                            <TaskBox
                                description={element.text} 
                                isTaskComplete={element.isComplete}
                                handleTaskDeleteFn={() => handleTaskDeleteFn(element.id)}
                                handleDoneTaskFn={() => handleDoneTaskFn(element.id)}
                                handleTaskEditFn={() => handleTaskEditFn(element)}
                                key={element.id}
                            />
                        ))
                    }
                </main>
            ) : null
        }
    </section>
  )
}
