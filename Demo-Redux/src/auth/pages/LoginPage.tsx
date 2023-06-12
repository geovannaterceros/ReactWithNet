import { Alert, Button, Grid, TextField, Typography } from '@mui/material';
import AuthLayout from '../layout/AuthLayout';
import { Google } from '@mui/icons-material';
import useForm from '~/hooks/useForm';
import { startGoogleSignIn, startLoginWithEmailPassword } from '~/store/auth/thunks';
import { useDispatch, useSelector } from 'react-redux';
import { AnyAction, ThunkDispatch } from '@reduxjs/toolkit';
import { RootState } from '~/store';
import { useNavigate } from 'react-router-dom';

export default function LoginPage() {
  const navigate = useNavigate();
  const dispatch = useDispatch<ThunkDispatch<RootState, unknown, AnyAction>>();
  const { initialAuth } = useSelector((state: any) => state.auth);
  const { email, password, onInputChange } = useForm({ email: '', password: '' });

  const onGoogleSignIn = async () => {
    await dispatch(startGoogleSignIn());
    navigate('/plate');
  };

  const onSubmit = async (event: React.FormEvent) => {
    event.preventDefault();
    await dispatch(startLoginWithEmailPassword(email, password));
    //updateUser('Lizette');
    navigate('/plate');
  };
  return (
    <AuthLayout title='Login'>
      <form aria-label='submit-form' onSubmit={onSubmit}>
        <Grid container>
          <Grid item xs={12} sx={{ mt: 2 }}>
            <TextField
              label='Email'
              type='email'
              placeholder='correo@google.com'
              fullWidth
              name='email'
              value={email}
              onChange={onInputChange}
            />
          </Grid>

          <Grid item xs={12} sx={{ mt: 2 }}>
            <TextField
              label='Password'
              type='password'
              placeholder='password'
              fullWidth
              name='password'
              value={password}
              onChange={onInputChange}
            />
          </Grid>
          <Grid
            container
            display={initialAuth.errorMessage !== 'Error autenticated' ? '' : 'none'}
            sx={{ mt: 1 }}
          >
            <Grid item xs={12}>
              <Alert severity='error'>{initialAuth.errorMessage}</Alert>
            </Grid>
          </Grid>
          <Grid container spacing={2} sx={{ mb: 2, mt: 1 }}>
            <Grid item xs={12} sm={6}>
              <Button variant='contained' type='submit' fullWidth>
                Login
              </Button>
            </Grid>
            <Grid item xs={12} sm={6}>
              <Button
                variant='contained'
                onClick={onGoogleSignIn}
                // disabled={isAuthenticating}
                fullWidth
              >
                <Google />
                <Typography sx={{ ml: 1 }}>Google</Typography>
              </Button>
            </Grid>
          </Grid>
        </Grid>
      </form>
    </AuthLayout>
  );
}
