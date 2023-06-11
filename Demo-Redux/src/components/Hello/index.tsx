import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { AnyAction, ThunkDispatch } from '@reduxjs/toolkit';
import { RootState } from '~/store';
import { ThunkGetPokemon } from '~/store/pokemon/thunks';
import {
  ThunkDeletePlate,
  ThunkGetPlate,
  ThunkPostPlate,
  ThunkUpdatePlate,
} from '../../store/plate/thunks';
import { Plate } from '~/plate/modals/Plate.models';

const Hello = () => {
  const dispatch = useDispatch<ThunkDispatch<RootState, unknown, AnyAction>>();
  const { isLoading, pokemon = [], page } = useSelector((state: any) => state.pokemon);

  console.log(isLoading);
  const disptachPlate = useDispatch<ThunkDispatch<RootState, unknown, AnyAction>>();

  const plate: Plate = {
    id: '387ca74c-376b-4e28-a80f-33ee4cec1c2f',
    name: 'Picante 10',
    dateActivity: new Date(),
    offer: false,
  };

  const id = '387ca74c-376b-4e28-a80f-33ee4cec1c2f';

  useEffect(() => {
    dispatch(ThunkGetPokemon());
    disptachPlate(ThunkGetPlate());
    //  disptachPlate(ThunkPostPlate(plate));
    //disptachPlate(ThunkDeletePlate(id));
    // disptachPlate(ThunkUpdatePlate(id, plate));
  }, []);
  return (
    <div
      style={{
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: 'center',
        textAlign: 'center',
        paddingTop: '50px',
      }}
    >
      <h1>Pokemon App</h1>
      <hr />
      <span>Loading: {isLoading ? 'True' : 'False'} </span>
      <ul>
        {pokemon.map(({ name }: any) => (
          <li key={name}>{name}</li>
        ))}
      </ul>
      <button disabled={isLoading} onClick={() => dispatch(ThunkGetPokemon(page))}>
        Next
      </button>
    </div>
  );
};

export default Hello;
