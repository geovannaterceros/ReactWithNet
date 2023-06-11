import { LogoutOutlined, MenuOutlined } from '@mui/icons-material';
import { AppBar, Grid, IconButton, Toolbar, Typography } from '@mui/material';
import { AnyAction, ThunkDispatch } from '@reduxjs/toolkit';
import { useDispatch } from 'react-redux';
import { RootState } from '~/store';
import { startLogout } from '~/store/auth/thunks';

interface Props {
  title: string;
}
export default function NavBar(props: Props) {
  const { title } = props;
  const dispatch = useDispatch<ThunkDispatch<RootState, unknown, AnyAction>>();

  const handleLogout = () => {
    dispatch(startLogout());
  };
  return (
    <AppBar
      position='fixed'
      sx={{
        width: { sm: `calc(100%)` },
      }}
    >
      <Toolbar>
        <IconButton color='inherit' edge='start' sx={{ mr: 2, display: { sm: 'none' } }}>
          <MenuOutlined />
        </IconButton>

        <Grid container direction='row' justifyContent='space-between' alignItems='center'>
          <Typography variant='h6' noWrap component='div'>
            {' '}
            {title}{' '}
          </Typography>

          <IconButton color='error' onClick={handleLogout}>
            <LogoutOutlined />
          </IconButton>
        </Grid>
      </Toolbar>
    </AppBar>
  );
}
