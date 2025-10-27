import React, { useEffect, useState } from 'react';
import { TextField, Button, Paper, Stack } from '@mui/material';
import client from '../apollo/client';
import { ADD_BOOK, UPDATE_BOOK } from '../graphql/mutations';
import type { Book } from '../types/Book';

interface Props {
  selectedBook: Book | null;
  onDone: () => void;
}

const BookForm: React.FC<Props> = ({ selectedBook, onDone }) => {
  const [title, setTitle] = useState('');
  const [author, setAuthor] = useState('');
  const [price, setPrice] = useState<number>(0);
  const [isUpdating, setIsUpdating] = useState(false);

  useEffect(() => {
    if (selectedBook) {
      setTitle(selectedBook.title);
      setAuthor(selectedBook.author);
      setPrice(Number(selectedBook.price));
      setIsUpdating(true);
    } else {
      setTitle('');
      setAuthor('');
      setPrice(0);
      setIsUpdating(false);
    }
  }, [selectedBook]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      await client.mutate({
        mutation: isUpdating ? UPDATE_BOOK : ADD_BOOK,
        variables: {
          ...(isUpdating ? { id: selectedBook?.id } : {}),
          title,
          author,
          price: parseFloat(price.toString()),
        },
      });

      onDone(); 
      setTitle('');
      setAuthor('');
      setPrice(0);
      setIsUpdating(false);
    } catch (error) {
      console.error('Error saving book:', error);
    }
  };

  return (
    <Paper sx={{ p: 3 }}>
      <form onSubmit={handleSubmit}>
        <Stack spacing={2} alignItems="center">
    <TextField
    label="Title"
    value={title}
    onChange={(e) => setTitle(e.target.value)}
    fullWidth
    required
    />  
    <TextField
    label="Author"
    value={author}
    onChange={(e) => setAuthor(e.target.value)}
    fullWidth
    required
    />
    <TextField
    label="Price"
    type="number"
    value={price}
    onChange={(e) => setPrice(Number(e.target.value))}
    fullWidth
    required
    />
    <Button
    type="submit"
    variant="contained"   
    color="primary"       
    sx={{
    alignSelf: 'center',
    px: 4,
    fontWeight: 500,
    borderRadius: 2,
    boxShadow: 2,
    transition: 'all 0.2s ease-in-out',
    '&:hover': {
      boxShadow: 4,
      transform: 'translateY(-2px)', 
    },
   }}
   >
   {isUpdating ? 'Update Book' : 'Add Book'}
 </Button>


<h1>Update Book</h1>
<p>Here we can update the book</p>
<Button>Click Update</Button>
<h1>Updation</h1>
<p>Update the Book</p>


</Stack>
</form>
</Paper>
  );
};

export default BookForm;
