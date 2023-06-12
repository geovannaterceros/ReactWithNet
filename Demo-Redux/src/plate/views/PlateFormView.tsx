import { Button, Grid, MenuItem, TextField } from '@mui/material';
import { LocalizationProvider } from '@mui/x-date-pickers';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import dayjs from 'dayjs';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { useNavigate } from 'react-router-dom';
import { Plate } from '../modals/Plate.models';
import useForm from '~/hooks/useForm';
import { useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { AnyAction, ThunkDispatch } from '@reduxjs/toolkit';
import { RootState } from '~/store';
import { ThunkPostPlate, ThunkUpdatePlate } from '~/store/plate/thunks';
import { offers } from '../modals/OfferList.models';

interface Props {
  plate?: Plate;
}

export default function PlateFormView(props: Props) {
  const { plate } = props;
  const navigate = useNavigate();
  const { name, onInputChange } = useForm({ name: plate?.name ?? '' });
  const [selectedDate, setSelectedDate] = useState<any | null>(dayjs(plate?.dateActivity));
  const [selectedOffer, setSelectedOffer] = useState<string>(plate?.offer ? 'true' : 'false');

  const dispatch = useDispatch<ThunkDispatch<RootState, unknown, AnyAction>>();
  const { initialAuth } = useSelector((state: any) => state.auth);

  const onSubmit = (event: React.FormEvent) => {
    event.preventDefault();
    if (plate !== undefined) {
      const plateUpdate: Plate = {
        id: plate.id,
        name: name,
        dateActivity: new Date(selectedDate),
        offer: selectedOffer === 'true',
      };
      dispatch(ThunkUpdatePlate(plate.id, plateUpdate));
    } else {
      const plateCreated: Plate = {
        name: name,
        dateActivity: new Date(selectedDate),
        offer: selectedOffer === 'true',
        uidUser: initialAuth.uid,
      };
      dispatch(ThunkPostPlate(plateCreated));
    }

    navigate('/plate');
  };

  return (
    <form aria-label='submit-form' onSubmit={onSubmit}>
      <Grid container>
        <Grid item xs={12} sx={{ mt: 2 }}>
          <TextField
            id='outlined-basic'
            type='text'
            placeholder='Name'
            fullWidth
            name='name'
            value={name}
            onChange={onInputChange}
          />
        </Grid>
        <Grid item xs={12} sx={{ mt: 2 }}>
          <LocalizationProvider dateAdapter={AdapterDayjs}>
            <DatePicker
              label='Date Activity'
              defaultValue={dayjs(dayjs(selectedDate).format('YYYY-MM-DD'))}
              onChange={(date: any | null) => setSelectedDate(date)}
              sx={{ width: '100%' }}
            />
          </LocalizationProvider>
        </Grid>
        <Grid item xs={12} sx={{ mt: 2 }}>
          <TextField
            id='outlined-select-currency'
            select
            label='Offer'
            value={selectedOffer}
            fullWidth
            name='offer'
            onChange={(event) => setSelectedOffer(event.target.value)}
          >
            {offers.map((option) => (
              <MenuItem key={option.value} value={option.value}>
                {option.label}
              </MenuItem>
            ))}
          </TextField>
        </Grid>
        <Grid item xs={12} sx={{ mt: 2 }}>
          <Button variant='contained' type='submit' fullWidth>
            {' '}
            Save{' '}
          </Button>
        </Grid>
      </Grid>
    </form>
  );
}
