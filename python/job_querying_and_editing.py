import requests
import json
import uuid

# port and ip of server to connect to
ip = '127.0.0.1'
port = 9707

baseUrl = f'http://{ip}:{port}/rest/api/v1/'

# Create a new sample job as json
def create_job(id, name, description):
	job_str = """
        {
          "Name": "Job",
          "Description": "",
          "Id": "5b8b3447-8e62-4aa8-959d-d089be1e76f4",
          "DoorData": {
            "Name": "",
            "Description": "",
            "Width": "36",
            "Length": "80",
            "Thickness": "1.375",
            "Hand": "RightHand",
            "HingeSideBevel": "3",
            "LockSideBevel": "0",
            "FeedRatePercentOverride": "100",
            "DoorFaceMaterial": "Wood",
            "DoorLockMaterial": "Wood",
            "DoorHingeMaterial": "Wood"
          },
          "FeatureGroups": [
            {
              "Name": "Hinges",
              "Description": "",
              "Id": "9b7297ed-1a84-4f16-a69e-19a7c606fd2d",
              "Locations": [
                {
                  "TLocation": 0,
                  "WLocation": 0,
                  "LLocation": 42
                }
              ],
              "TDoorReference": "HingePivot",
              "WDoorReference": "Lock",
              "LDoorReference": "Top",
              "Children": [
                {
                  "Type": "Hinge",
                  "Bevel": "$Door.HingeBevel",
                  "Length": "3.5",
                  "Backset": ".25",
                  "Depth": ".08",
                  "Radius1": ".625",
                  "Radius2": ".625",
                  "IsPredrillOn": true,
                  "PredrillDiameter": ".125",
                  "PredrillDepth": ".375",
                  "PredrillLocations": [
                    {
                      "X": "-1.406",
                      "Y": "0.6875"
                    },
                    {
                      "X": "0",
                      "Y": "0.3438"
                    },
                    {
                      "X": "1.406",
                      "Y": "0.6875"
                    }
                  ],
                  "Name": "Door Hinges",
                  "Description": "",
                  "TLocation": "Width / 2.0",
                  "WLocation": "0.0",
                  "LLocation": "length/2",
                  "DoorSide": "Hinge",
                  "Children": []
                },
                {
                  "Type": "Hinge",
                  "Bevel": "0.0",
                  "Length": "3.5",
                  "Backset": ".25",
                  "Depth": ".08",
                  "Radius1": ".625",
                  "Radius2": ".625",
                  "IsPredrillOn": true,
                  "PredrillDiameter": ".125",
                  "PredrillDepth": ".375",
                  "PredrillLocations": [
                    {
                      "X": "-1.406",
                      "Y": "0.6875"
                    },
                    {
                      "X": "0",
                      "Y": "0.3438"
                    },
                    {
                      "X": "1.406",
                      "Y": "0.6875"
                    }
                  ],
                  "Name": "",
                  "Description": "",
                  "TLocation": "Width / 2.0",
                  "WLocation": "0.0",
                  "LLocation": "length/2",
                  "DoorSide": "HingeJamb",
                  "Children": []
                }
              ]
            }
          ]
        }"""
	job_json = json.loads(job_str)
	job_json['Name'] = name
	job_json['Id'] = id
	job_json['Description'] = description
	return job_json

def print_json(json_data):
	print(json.dumps(json_data, indent=2, separators=(',',':')))	
	
def create_upsert_job_request(job):
    return { "DoorJob": job }

# upsert a door job object to the library (inserts if id not found, updates if id matches existing job)
def upsert_door_job(job):
	url = baseUrl + 'doorjobs'
	json_data = create_upsert_job_request(job)
	with requests.session() as session:
		r = session.put(url, json=json_data)
		if r.status_code != 200:
			raise Exception(f'Failed to upsert door job: {r.json()}')
			
# retrieve a door job object from the library by id or None if id not found
def get_door_job_by_id(id):
	url = baseUrl + 'doorjobs/search'
	json_data = { 'Id': id }
	with requests.session() as session:
		r = session.post(url, json=json_data)
		if r.status_code != 200:
			raise Exception(f'Failed to get door job by id: {r.json()}')
		
		json_reply = r.json()
		
		if len(json_reply['Results']) > 0:
			return json_reply['Results'][0]
		else:
			print(f'Job with id: {id} not found')
			return None

# get all the door job headers	
def get_door_job_headers():
	url = baseUrl + 'doorjobs/headers'
	with requests.session() as session:
		return session.get(url).json()
		

# get all door jobs whose name contains the string given, percent ('%') and undescore ('_') characters must be escaped with backslash ('\')
def jobs_with_name_containing(strInName):
	url = baseUrl + 'doorjobs/search'
	# using '%' wild card character for a contains search
	json_data = { 'Name': '%' + strInName + '%' }
	with requests.session() as session:
		r = session.post(url, json=json_data)
		if r.status_code != 200:
			raise Exception(f'Failed to search for jobs with name containing a string: {r.json()}')
		
		json_reply = r.json()
		return r.json()['Results']


job_id = str(uuid.uuid4())
job = create_job(job_id, f'Python Job {job_id[:8]}', f'Job id: {job_id}')		
print(f'Upserting door job with id: {job_id}')
upsert_door_job(job)

print('Querying just upserted door job using id')
print_json(get_door_job_by_id(job_id))

# uncomment to print all door job headers
# print('Querying all door job headers')
# print_json(get_door_job_headers())

print('Querying all jobs with "python" in the name')
print_json(jobs_with_name_containing('python'))
