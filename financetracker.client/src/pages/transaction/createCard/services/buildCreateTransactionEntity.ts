import { ICreateTransactionEntity } from '../../../../types/ICreateTransactionEntity';

export const buildCreateTransactionEntity = (
  name: string,
  category: string,
  description: string,
  price: number,
  year: number,
  month: number,
  day: number,
): ICreateTransactionEntity => {
  const dateTransaction = new Date(year, month, day);

  const newTransaction: ICreateTransactionEntity = {
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
