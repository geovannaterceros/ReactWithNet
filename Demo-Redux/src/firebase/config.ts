// Import the functions you need from the SDKs you need
import { initializeApp } from 'firebase/app';
import { getAuth } from 'firebase/auth';
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
  apiKey: 'AIzaSyBmko4hGaW_XyqrMtuhZiHw_Y9VUUtwoQU',
  authDomain: 'react-demo-773b1.firebaseapp.com',
  projectId: 'react-demo-773b1',
  storageBucket: 'react-demo-773b1.appspot.com',
  messagingSenderId: '643183342399',
  appId: '1:643183342399:web:481c3af610ecfc07c1198a',
  measurementId: 'G-RRFSRL4V58',
};

// Initialize Firebase
export const FirebaseApp = initializeApp(firebaseConfig);
export const FirebaseAuth = getAuth(FirebaseApp);
