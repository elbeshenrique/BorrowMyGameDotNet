import React from 'react';
import { BrowserRouter } from 'react-router-dom';
import './App.css';
import MainPage from './Pages/MainPage';

function App() {
    return (
        <BrowserRouter>
            <MainPage></MainPage>
        </BrowserRouter>
    );
}

export default App;
