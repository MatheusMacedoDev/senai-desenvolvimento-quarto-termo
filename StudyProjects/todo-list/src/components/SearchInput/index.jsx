import React, { useState } from 'react';
import './style.css';
import { IoSearchSharp } from "react-icons/io5";

export default function SearchInput({ text, setText }) {
    return (
        <section className="search-input-wrapper">
            <IoSearchSharp 
                size={18} 
                color='#FCFCFC' 
                style={{position: 'absolute', left: 10}}
            />
            <input 
                type='text' 
                value={text} 
                className='search-input'
                onChange={e => setText(e.target.value)} 
                placeholder='Procurar tarefa'
            />
        </section>
    )
}
