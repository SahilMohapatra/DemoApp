import React from 'react';
import { ThemeProvider, CssBaseline } from '@mui/material';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import theme from './theme/theme';
import BookPage from './pages/BookPage';
import AddBookPage from './pages/AddBookPage';

const App: React.FC = () => {
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Router>
        <Routes>
          <Route path="/" element={<Navigate to="/books" />} />
          <Route path="/books" element={<BookPage />} />
          <Route path="/add" element={<AddBookPage />} />
        </Routes>
      </Router>
    </ThemeProvider>
  );
};  

export default App;


