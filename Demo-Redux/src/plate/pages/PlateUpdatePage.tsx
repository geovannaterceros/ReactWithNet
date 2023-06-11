import { useParams } from 'react-router-dom';
import PlateLayout from '../layout/PlateLayout';
import PlateLayoutForm from '../layout/PlateLayoutForm';
import PlateFormView from '../views/PlateFormView';
import { AnyAction, ThunkDispatch } from '@reduxjs/toolkit';
import { RootState } from '~/store';
import { useDispatch, useSelector } from 'react-redux';
import { useEffect, useRef } from 'react';
import { ThunkGetPlateId } from '~/store/plate/thunks';
import { CheckingAuth } from '~/ui/CheckingAuth';

export default function PlateUpdatePage() {
  const { id } = useParams();

  const dispatch = useDispatch<ThunkDispatch<RootState, unknown, AnyAction>>();
  const { plate } = useSelector((state: any) => state.plate);
  const prevPlateRef = useRef(plate);

  useEffect(() => {
    dispatch(ThunkGetPlateId(id));
  }, [dispatch, id]);

  useEffect(() => {
    if (prevPlateRef.current !== plate) {
      prevPlateRef.current = plate;
    }
  }, [plate]);

  if (!plate || prevPlateRef.current === plate) {
    return <CheckingAuth />;
  }

  return (
    <PlateLayout>
      <PlateLayoutForm title={'Update Plate'}>
        <PlateFormView plate={plate} />
      </PlateLayoutForm>
    </PlateLayout>
  );
}
