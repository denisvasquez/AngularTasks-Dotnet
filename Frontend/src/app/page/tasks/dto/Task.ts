interface Task {
  id: number;
  title: string;
  userId: number;
  description: string;
  createdAt: Date;
  updatedDate?: Date;
  isCompleted: boolean;
  active: boolean;
}
