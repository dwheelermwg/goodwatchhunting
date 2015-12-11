//
//  HealthSurveryor.swift
//  GoodWatchHuntingApp
//
//  Created by Derek Wheeler on 12/10/15.
//  Copyright © 2015 MyWebGrocer. All rights reserved.
//

import Foundation
import HealthKit

class HealthSurveyor {
    var heartRateQuery: HKQuery?
    var stepCountQuery: HKQuery?
    var surveyStartDate: NSDate?
    
    var currentHealthRecord: HealthRecord?
    
    init() {
        if self.heartRateQuery == nil {
            self.heartRateQuery = self.createStreamingHeartRateQuery()
        }
        self.stepCountQuery = nil
        self.surveyStartDate = nil
        self.currentHealthRecord = HealthRecord()
    }
    
    func authorizeHealthKit(completion: ((success:Bool, error:NSError!) -> Void)!) {
        let healthKitReadTypes: Set<HKObjectType> = Set([
            HKObjectType.quantityTypeForIdentifier(HKQuantityTypeIdentifierHeartRate)!,
            HKObjectType.quantityTypeForIdentifier(HKQuantityTypeIdentifierStepCount)!
            ])
        
        if HKHealthStore.isHealthDataAvailable() {
            healthStore.requestAuthorizationToShareTypes(nil, readTypes: healthKitReadTypes, completion: { (success, error) -> Void in
                if success {
                    print("SUCCESS")
                } else {
                    print(error!.description)
                }
            })
        } else {
            print("HealthKit is not available.")
        }
    }
    
    func startSurvey() {
        print("Starting health survery...")
        self.healthStore.executeQuery(self.heartRateQuery!)
        self.surveyStartDate = NSDate()
        self.surveyStartDate = self.surveyStartDate?.dateByAddingTimeInterval(-7*24*60*60)
    }
    
    func stopSurvey() {
        print("Finishing health survey...")
        self.stepCountQuery = createStepCountQuery()
        self.healthStore.executeQuery(self.stepCountQuery!)
        
        self.healthStore.stopQuery(self.heartRateQuery!)
        print("Finished!")
    }
    
    // =========================================================================
    // MARK: - Private
    let healthStore = HKHealthStore()
    
    let heartRateType = HKQuantityType.quantityTypeForIdentifier(HKQuantityTypeIdentifierHeartRate)!
    let heartRateUnit = HKUnit(fromString: "count/min")
    
    private func createStreamingHeartRateQuery() -> HKQuery {
        let predicate = HKQuery.predicateForSamplesWithStartDate(NSDate(), endDate: nil, options: .None)
        
        let query = HKAnchoredObjectQuery(type: heartRateType, predicate: predicate, anchor: nil, limit: Int(HKObjectQueryNoLimit)) { (query, samples, deletedObjects, anchor, error) -> Void in
            self.addHeartRateSamples(samples)
        }
        query.updateHandler = { (query, samples, deletedObjects, anchor, error) -> Void in
            self.addHeartRateSamples(samples)
        }
        
        return query
    }
    
    let stepCountType = HKQuantityType.quantityTypeForIdentifier(HKQuantityTypeIdentifierStepCount)
    let stepCountUnit = HKUnit(fromString: "count")
    
    private func createStepCountQuery() -> HKQuery {
        let endDate = NSDate()
        let dateFormatter = NSDateFormatter()
        self.currentHealthRecord?.time = dateFormatter.stringFromDate(endDate)
        let predicate = HKQuery.predicateForSamplesWithStartDate(self.surveyStartDate, endDate: endDate, options:.StrictStartDate)
        let query = HKSampleQuery(sampleType: stepCountType!, predicate: predicate, limit: 0, sortDescriptors: nil, resultsHandler: {
            (query, results, error) in
            print("Getting steps between \(self.surveyStartDate) and \(endDate)")
            if results == nil {
                print("There was an error running the query: \(error)")
            } else {
                print("Steps = \(results)")
                dispatch_async(dispatch_get_main_queue()) {
                    var dailyAVG:Double = 0
                    for steps in results as! [HKQuantitySample]
                    {
                        // add values to dailyAVG
                        dailyAVG += steps.quantity.doubleValueForUnit(HKUnit.countUnit())
                        print(dailyAVG)
                        print(steps)
                    }
                }
            }
        })
        
        return query
    }
    
    private func addHeartRateSamples(samples: [HKSample]?) {
        guard let samples = samples as? [HKQuantitySample] else { return }
        guard let hrquantity = samples.last?.quantity else { return }
        let currentHeartRate = hrquantity.doubleValueForUnit(heartRateUnit)
        print("Heart rate = \(currentHeartRate)")
        currentHealthRecord?.heartRate = currentHeartRate
    }
    private func addStepSamples(samples: [HKSample]?) {
        guard let samples = samples as? [HKQuantitySample] else { return }
        guard let hrquantity = samples.last?.quantity else { return }
        print("Step count = \(hrquantity.doubleValueForUnit(stepCountUnit))")
    }
}