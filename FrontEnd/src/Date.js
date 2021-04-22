import React, { useState } from 'react'
import DatePicker from 'react-datepicker'
import 'react-datepicker/dist/react-datepicker.css'

startDate = null;
endDate = null;

function Date(namedate) {

    const [selectedDate, setSelectedDate] = useState(null)

    return (
        <div className='Date'>
            <DatePicker
                name={namedate}
                selected={selectedDate}
                onChange={date => setSelectedDate(date)}
                placeholderText={'yyyy/mm/dd'}
                showYearDropdown
                scrollableYearDropdown
            />
        </div>
    )
}

export default Date;