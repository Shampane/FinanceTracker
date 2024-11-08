import axios from 'axios';
import { IRequestTransactionEntity } from '../../../../types/IRequestTransactionEntity';

export class CreateTransaction {
  public create = async (
    url: string,
    entity: IRequestTransactionEntity,
  ): Promise<void> => {
    await axios.post(url, entity);
  };
}
