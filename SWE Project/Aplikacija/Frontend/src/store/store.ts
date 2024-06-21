import { configureStore } from "@reduxjs/toolkit";
import { persistStore, persistReducer } from "redux-persist";
import storage from "redux-persist/lib/storage";
import {
  FLUSH,
  REHYDRATE,
  PAUSE,
  PERSIST,
  PURGE,
  REGISTER,
} from "redux-persist";

import selectedEventReducer from "./features/selectedEvent";
import authReducer from "./features/auth";

const selectedEventPersistConfig = {
  key: "selectedEvent",
  storage: storage,
  blacklist: [
    "id",
    "title",
    "date",
    "location",
    "img",
    "time",
    "organizerID",
    "organizer",
  ],
};

const authPersistConfig = {
  key: "auth",
  storage: storage,
};

const rootReducer = {
  selectedEvent: persistReducer(
    selectedEventPersistConfig,
    selectedEventReducer
  ),
  auth: persistReducer(authPersistConfig, authReducer),
};

export const store = configureStore({
  reducer: rootReducer,
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({
      serializableCheck: {
        ignoredActions: [FLUSH, REHYDRATE, PAUSE, PERSIST, PURGE, REGISTER],
      },
    }),
});

export let persistor = persistStore(store);

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
