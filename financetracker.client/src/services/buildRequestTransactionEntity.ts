import { IRequestTransactionEntity } from '../types/IRequestTransactionEntity';

export const buildRequestTransactionEntity = (
  name: string,
  category: string,
  description: string,
  price: number,
  year: number,
  month: number,
  day: number,
): IRequestTransactionEntity => {
  const newTransaction: IRequestTransactionEntity = {
    name,
    category,
    description,
    price,
    year,
    month,
    day,
  };
  return newTransaction;
};
