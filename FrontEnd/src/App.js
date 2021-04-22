import React from 'react'
import Stock from './Stock';
import Button from './Button';
import logoSvg from './assets/img/robot.svg';
import { useForm } from "react-hook-form";
import './App.css';

function App() {
  const { register, handleSubmit } = useForm()

  const onSubmit = (data) => {
    console.log(data)
  }

  return (
    <div className="wrapper">
      <div className="header">
        <div className="container">
          <div className="header__logo">
            <img width="38" src={logoSvg} alt="Robot logo" />
            <div>
              <h1>Trading strategy tester</h1>
              <p>Find an entrance and exit from any situation</p>
            </div>
          </div>
          <div className="header__logo1">
            <div>
              <Button onClick={() => alert(555)} outline>ABOUT US</Button>
            </div>
          </div>


        </div>
      </div>
      <div className="content">
        <div className="container">
          <div className="content__top">
            <div className="sort">

            </div>
          </div>
          <div className="content__items">
            <Stock></Stock>
            <form onSubmit={handleSubmit(onSubmit)}>
              <input type="file" {...register('picture')} />
              <Button onClick={() => alert("File is uploaded")}>Submit</Button>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
