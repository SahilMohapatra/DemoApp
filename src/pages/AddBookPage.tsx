import React from 'react';
import { useLocation, useNavigate } from 'react-router-dom';
import { Container, Typography, Paper, Button } from '@mui/material';
import BookForm from '../components/BookForm';
import type { Book } from '../types/Book';

const AddBookPage: React.FC = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const selectedBook = (location.state as { book?: Book })?.book || null;

  const handleDone = () => navigate('/books');
   
  return (
    <Container sx={{ mt: 4 }}>
      <Paper sx={{ p: 4, boxShadow: 3 }}>
        <Typography variant="h5" gutterBottom>
          {selectedBook ? '✏️ Edit Book' : '➕ Add New Book'}
        </Typography>

        <BookForm selectedBook={selectedBook} onDone={handleDone} />

        <Button sx={{ mt: 2 }} variant="outlined" color="secondary" onClick={() => navigate('/books')}>
          ← Back to Books
        </Button>
        
      </Paper>
    </Container>
  );
};

export default AddBookPage;
