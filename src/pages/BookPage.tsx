import React, { useState } from 'react';
import { Container, Typography, Divider, Button, Box } from '@mui/material';
import { useNavigate } from 'react-router-dom';
import BookList from '../components/BookList';
import type { Book } from '../types/Book';

const BookPage: React.FC = () => {
  const [selectedBook, setSelectedBook] = useState<Book | null>(null);
  const [refreshFlag, setRefreshFlag] = useState(false);
  const navigate = useNavigate();

  const handleEdit = (book: Book) => {
    navigate('/add', { state: { book } });
  };
                                          
  return (      
    <Container sx={{ mt: 4 }}>
      <Box display="flex" justifyContent="space-between" alignItems="center">
        <Typography variant="h4">📚 Bookstore Management</Typography>
        <Button variant="contained" color="primary" onClick={() => navigate('/add')}>
          ➕ Add Book
        </Button>
      </Box>

      <Divider sx={{ my: 3 }} />

      <BookList onSelectBook={handleEdit} refreshFlag={refreshFlag} />
    </Container>
  );
};

export default BookPage;
