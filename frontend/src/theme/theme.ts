import { createTheme } from '@mui/material/styles';

const theme = createTheme({
  palette: {
    mode: 'light',
    primary: {
      main: '#1976d2', 
    },
    background: {
      default: '#92a3b2ff', 
      paper: '#d7f3faff',  
    },
  },
  typography: {
    fontFamily: 'Roboto, sans-serif',
    h4: { fontWeight: 600 },
    button: { textTransform: 'none' },
  },
  shape: {
    borderRadius: 12,
  },
});

export default theme;
