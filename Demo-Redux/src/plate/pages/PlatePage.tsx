import { Button, Grid, Typography } from '@mui/material';
import PlateLayout from '../layout/PlateLayout';
import PlateTableView from '../views/PlateTableView';
import { useNavigate } from 'react-router-dom';
import { useSelector } from 'react-redux';
import { useDispatch } from 'react-redux';
import { AnyAction, ThunkDispatch } from '@reduxjs/toolkit';
import { RootState } from '~/store';
import { useEffect } from 'react';
import { ThunkGetPlate } from '~/store/plate/thunks';
export default function PlatePage() {
  const dispatch = useDispatch<ThunkDispatch<RootState, unknown, AnyAction>>();
  const navigate = useNavigate();

  const handleCreate = () => {
    navigate('/plate/create');
  };

  useEffect(() => {
    dispatch(ThunkGetPlate());
  }, [dispatch]);

  return (
    <PlateLayout>
      <Grid container direction='column' sx={{ mb: 1 }} spacing={4}>
        <Grid item>
          <Typography variant='h4' align='center'>
            Plate
          </Typography>
        </Grid>
        <Grid item>
          <Button variant='contained' sx={{ textAlign: 'left' }} onClick={handleCreate}>
            {' '}
            Add Plate{' '}
          </Button>
        </Grid>
        <Grid item>
          <PlateTableView />
        </Grid>
      </Grid>
    </PlateLayout>
  );
}
