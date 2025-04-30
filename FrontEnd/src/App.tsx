import React from 'react';
import { BrowserRouter, Routes, Route } from 'react-router-dom';
import BlogList from './components/BlogList';
import BlogDetail from './components/BlogDetail';
import './App.css';

// Picks which components to render based on the URL
const App: React.FC = () => {
    return (
        <BrowserRouter>
            <div className="App">
                <header className="App-header">
                </header>
                <main>
                    <Routes>
                        <Route path="/" element={<BlogList />} />
                        <Route path="/posts/:id" element={<BlogDetail />} />
                    </Routes>
                </main>
            </div>
        </BrowserRouter>
    );
};

export default App;