import { gql } from '@apollo/client';

export const ADD_BOOK = gql`
  mutation AddBook($title: String!, $author: String!, $price: Decimal!) {
    addBook(title: $title, author: $author, price: $price) {
      id
      title
      author
      price
    }
  }
`;

export const UPDATE_BOOK = gql`
  mutation UpdateBook($id: Int!, $title: String!, $author: String!, $price: Decimal!) {
    updateBook(id: $id, title: $title, author: $author, price: $price) {
      id
      title
      author
      price
    }
  }
`;

export const DELETE_BOOK = gql`
  mutation DeleteBook($id: Int!) {
    deleteBook(id: $id)
  }
`;


