import { PayloadAction, createSlice } from "@reduxjs/toolkit";

export interface AuthState {
  userId: string;
  token: string;
  email: string;
  firstName: string;
  lastName: string;
  phoneNumber: string;
  birthday: string;
  userType: "Visitor" | "Space owner" | "Host" | "Unregistered" | "Admin";
  avatar: string | null;
  address: string | null;
  city: string | null;
}

const initialState: AuthState = {
  userId: "",
  token: "",
  firstName: "",
  lastName: "",
  email: "",
  phoneNumber: "",
  birthday: "",
  userType: "Unregistered",
  avatar: null,
  address: null,
  city: null,
};

export const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {
    login: (state, action: PayloadAction<AuthState>) => {
      state.userId = action.payload.userId;
      state.token = action.payload.token;
      state.email = action.payload.email;
      state.firstName = action.payload.firstName;
      state.birthday = action.payload.birthday;
      state.phoneNumber = action.payload.phoneNumber;
      state.lastName = action.payload.lastName;
      state.userType = action.payload.userType;
      state.avatar = action.payload.avatar;
      state.address = action.payload.address;
      state.city = action.payload.city;
    },
    logout: (state) => {
      Object.assign(state, initialState);
    },
  },
});

export const { login, logout } = authSlice.actions;
export default authSlice.reducer;
