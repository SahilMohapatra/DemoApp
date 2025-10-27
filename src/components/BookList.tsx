import React, { useEffect, useState } from 'react';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, Button } from '@mui/material';
import client from '../apollo/client';
import { GET_BOOKS } from '../graphql/queries';
import { DELETE_BOOK } from '../graphql/mutations';
import type { Book } from '../types/Book';

interface Props {
  onSelectBook: (book: Book) => void;
  refreshFlag: boolean; 
}

const BookList: React.FC<Props> = ({ onSelectBook, refreshFlag }) => {
  const [books, setBooks] = useState<Book[]>([]);
  const [loading, setLoading] = useState<boolean>(false);
  const [errorMessage, setErrorMessage] = useState<string | null>(null);
  
  const fetchBooks = async () => {
    setLoading(true);
    setErrorMessage(null);
    try {
      const result = await client.query<{ books: Book[] }>({
        query: GET_BOOKS,
        fetchPolicy: 'network-only', 
      });
      setBooks(result.data?.books || []);
    } catch (error) {
      console.error('Error fetching books:', error);
      setErrorMessage('Failed to load books');
    } finally {
      setLoading(false);
    }
  };
  
  
  const handleDelete = async (id: number) => {
    try {
      await client.mutate({
        mutation: DELETE_BOOK,
        variables: { id },
      });
      await fetchBooks(); 
    } catch (error) {
      console.error('Error deleting book:', error);
      setErrorMessage('Failed to delete book');
    }
  };

  useEffect(() => {
    fetchBooks();
  }, [refreshFlag]); 

  if (loading) return <p>Loading books...</p>;
  if (errorMessage) return <p>{errorMessage}</p>;

  return (
    <TableContainer component={Paper}>
      <Table>
        <TableHead>
          <TableRow>
            <TableCell>Title</TableCell>
            <TableCell>Author</TableCell>
            <TableCell>Price</TableCell>
            <TableCell>Actions</TableCell>
          </TableRow>
        </TableHead>
        <TableBody>
          {books.map((book) => (
            <TableRow key={book.id}>
              <TableCell>{book.title}</TableCell>
              <TableCell>{book.author}</TableCell>
              <TableCell>{Number(book.price).toFixed(2)}</TableCell>
              <TableCell>
                <Button
                 variant="outlined"
                 onClick={() => onSelectBook(book)} 
                 >
                 Edit
                </Button>

                <Button
                  variant="contained"
                  color="error"
                  sx={{ ml: 2 }}
                  onClick={() => handleDelete(book.id)}
                >
                  Delete
                </Button>
              </TableCell>
            </TableRow>
          ))}
        </TableBody>
      </Table>
    </TableContainer>
  );
};

export default BookList;
