import { create } from 'zustand';

export const useMusicStore = create((set) => ({
  selectdMusic: '',
  selectMusic: (name) => set({ selectdMusic: name })
}))