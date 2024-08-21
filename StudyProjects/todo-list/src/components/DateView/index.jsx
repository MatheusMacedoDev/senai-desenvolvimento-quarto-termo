import React, { useEffect, useState } from 'react';
import './style.css';

const daysOfWeek = ['Domingo', 'Segunda-Feira', 'Terça-Feira', 'Quarta-Feira', 'Quinta-Feira', 'Sexta-Feira', 'Sábado'];
const mounths = ['Janeiro', 'Fevereiro', 'Março', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro']

export default function DateView() {
    const [date, setDate] = useState(new Date())

    return (
        <h2 className='date-text'>{daysOfWeek[date.getUTCDay()]}, <span className="highlighted">{date.getDate()}</span> de {mounths[date.getUTCMonth()]}</h2>
    )
}
