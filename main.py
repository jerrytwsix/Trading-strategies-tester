###
#import strategy.py
#Должны быть заложены функции buy & sell
###

import json
import pandas as pd
from binance.client import Client

class Json_deserializer():

    def deserialize_candles_json_to_list_of_dicts(self):
        with open (self.PATH + "\\" + self.json_candles_filename, 'r') as file_json:  
            candles_dict = json.load(file_json)

        #debug print
        print(candles_dict.values())
        ###
        return candles_dict.values()

    def __init__(self, PATH, json_candles_filename):
        self.PATH = PATH
        self.json_candles_filename = json_candles_filename

if __name__ == '__main__':
    PATH = r'C:\Users\ivfon\Strategy Tester'
    api_key = 'insert_key'
    api_secret = 'insert secret'
    valut_pair = 'insert pair'
    json_filename = 'japan_sticks.json'
    
    client = Client(api_key, api_key)
    deserializer = Json_deserializer(PATH, json_filename) 
    
    balance = client.get_asset_balance(asset=valut_pair)
    candles_list = deserializer.deserialize_candles_json_to_list_of_dicts()
    
    balance_usd = 1000.0
    balance_btc = 0.01
    
    test_result_df = pd.DataFrame(columns=['Balance_USDT', 'Balance_BTC', 'USDT_delta', 'BTC_delta', 'PRICE_BUY', 'PRICE_SELL'])

    #
    #Пусть выход операции пользователя будет таким(на примере buy в паре USDT/BTC): сколько потратили USDT, сколько купили BTC, за какую цену 
    #
    for i in len(candles_list):
        operation_buy_result = [0, 0, 0]
        operation_sell_result = [0, 0, 0]
        if balance_usd > 10:
            operation_buy_result = buy(candles_list[:i], balance_usd, balance_btc)
            balance_usd -= operation_buy_result[0]
            balance_btc += operation_buy_result[1]

        if balance_btc > 0.00001:
            operation_sell_result = sell(candles_list[:i], balance_usd, balance_btc)
            balance_usd += operation_sell_result[1]
            balance_btc -= operation_sell_result[0]
        
        USDT_delta = operation_sell_result[1] - operation_buy_result[0]
        BTC_delta = operation_buy_result[1] - operation_sell_result[0]

        temp_df = pd.DataFrame([[balance_usd], [balance_btc], [USDT_delta], [BTC_delta], [operation_buy_result[2]], [operation_sell_result[2]]], columns=['Balance_USDT', 'Balance_BTC', 'USDT_delta', 'BTC_delta', 'PRICE_BUY', 'PRICE_SELL'])
        test_result_df = test_result_df.append(temp_df)

    test_result_df.to_csv('tester_result.csv', index=False)
    

