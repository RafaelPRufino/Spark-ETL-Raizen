import pika
import json
import time
import sys

defaults = {
    'queue': {
        'queue': {
            'passive': False,
            'durable': True,
            'exclusive': False,
            'autoDelete': False,
            'nowait': False
        },
        'consumer': {
            'noLocal': False,
            'noAck': False,
            'exclusive': False,
            'nowait': False
        }
    }
}

class Message:
    def __init__(self, server):       
        self.server = server 
    
    def receive(self, callback):
        try:
            credentials = pika.PlainCredentials(self.server['user'], self.server['pass'])
            params = pika.ConnectionParameters(host=self.server['host'], credentials=credentials)

            connection = pika.BlockingConnection(params)
            channel = connection.channel()
            channel.queue_declare(queue=self.server['queue'], durable=True)

            def on_message(channel, method_frame, header_frame, body):          
                callback(body.decode('UTF-8'))
                channel.basic_ack(delivery_tag=method_frame.delivery_tag)

            channel.basic_consume(self.server['queue'], on_message)
            try:
                channel.start_consuming()
            except KeyboardInterrupt:
                channel.stop_consuming()
            connection.close()
        except:
            sys.exit(3)
       
       
          
def enqueue(server):
    return Message(server)




        