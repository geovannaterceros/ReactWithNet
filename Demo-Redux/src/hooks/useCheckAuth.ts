import { useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { onAuthStateChanged } from 'firebase/auth';

import { FirebaseAuth } from '../firebase/config';
import { InitialAuth, login, logout } from '~/store/auth/authSlice';
import { startLogout } from '~/store/auth/thunks';

export const useCheckAuth = () => {
  const dispatch = useDispatch();
  //dispatch(startLogout());
  useEffect(() => {
    onAuthStateChanged(FirebaseAuth, async (user) => {
      if (!user) {
        return dispatch(
          logout({ initialAuth: { errorMessage: 'Error autenticated' } as InitialAuth }),
        );
      }
      const userData: InitialAuth = {
        uid: user.uid,
        email: user.email,
        displayName: user.displayName,
        photoUrl: user.photoURL,
      };

      return await dispatch(login({ initialAuth: userData }));
    });
  }, [dispatch]);
};
